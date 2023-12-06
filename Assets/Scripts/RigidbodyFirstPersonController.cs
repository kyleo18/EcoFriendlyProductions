using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class RigidbodyFirstPersonController : MonoBehaviour
    {
        public PlayerController playerController;
        [Serializable]
        public class MovementSettings
        {
            public float ForwardSpeed = 2.0f;   // Speed when walking forward

            public float walkSpeed = 2.0f, runSpeed = 6.0f;
            //public float walkAirSpeed = 0.3f, runAirSpeed

            public float BackwardSpeed = 4.0f;  // Speed when walking backwards
            public float StrafeSpeed = 4.0f;    // Speed when walking sideways
            public float SpeedInAir = 8.0f;   // Speed when onair
            public float JumpForce = 30f;
            [HideInInspector] public float CurrentTargetSpeed = 8f;

#if !MOBILE_INPUT
            private bool m_Running;
#endif

            public void UpdateDesiredTargetSpeed(Vector2 input)
            {
                if (input == Vector2.zero) return;
                if (input.x > 0 || input.x < 0)
                {
                    //strafe
                    CurrentTargetSpeed = StrafeSpeed;
                }
                if (input.y < 0)
                {
                    //backwards
                    CurrentTargetSpeed = BackwardSpeed;
                }
                if (input.y > 0)
                {
                    //forwards
                    //handled last as if strafing and moving forward at the same time forwards speed should take precedence
                    CurrentTargetSpeed = ForwardSpeed;
                }

            }

        }


        public bool canrotate;
        public Camera cam;
        public MovementSettings movementSettings = new MovementSettings();
        public MouseLook mouseLook = new MouseLook();
        public Vector3 relativevelocity;

        public DetectObs detectGround;


        public bool Wallrunning;
        public bool isWalking;
        public bool isRunning;
        public bool hasLanded;



        private Rigidbody m_RigidBody;
        private CapsuleCollider m_Capsule;
        private float m_YRotation;
        private bool m_IsGrounded;


        public Vector3 Velocity
        {
            get { return m_RigidBody.velocity; }
        }

        public bool Grounded
        {
            get { return m_IsGrounded; }
        }




        private void Awake()
        {

            canrotate = true;
            m_RigidBody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();

            mouseLook.Init(transform, cam.transform);

            mouseLook.Init (transform, cam.transform);




        }


        private void Update()
        {


            //Sprinting
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movementSettings.ForwardSpeed = movementSettings.runSpeed;

                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movementSettings.ForwardSpeed = movementSettings.walkSpeed;

                isRunning = false;
            }




            relativevelocity = transform.InverseTransformDirection(m_RigidBody.velocity);
            if (m_IsGrounded)
            {

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    NormalJump();
                }

            }

        }



        /*void controllerJump()
        {
            if(m_IsGrounded)
            {
                NormalJump();
                playerController.jump();
            }
        }*/
        


        private void LateUpdate()
        {
            if (canrotate)
            {
                RotateView();
            }
            else
            {
                mouseLook.LookOveride(transform, cam.transform);
            }


        }
        public void CamGoBack(float speed)
        {
            mouseLook.CamGoBack(transform, cam.transform, speed);

        }
        public void CamGoBackAll()
        {
            mouseLook.CamGoBackAll(transform, cam.transform);

        }
        private void FixedUpdate()
        {
            GroundCheck();
            Vector2 input = GetInput();

            float h = input.x;
            float v = input.y;
            Vector3 inputVector = new Vector3(h, 0, v);
            inputVector = Vector3.ClampMagnitude(inputVector, 1);

            stopWalk();
            stopRun();
            stopWallRun();
            playerController.Stopmoving();

            //grounded
            if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) && m_IsGrounded && !Wallrunning)
            {
                if (Input.GetAxisRaw("Vertical") > 0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * movementSettings.ForwardSpeed * Mathf.Abs(inputVector.z));
                    playerController.moving();

                    if(isRunning == false)
                    {
                        playWalk();
                    }
                    else
                    {
                        playRun();
                    }
                }
                if (Input.GetAxisRaw("Vertical") < -0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * -movementSettings.BackwardSpeed * Mathf.Abs(inputVector.z));
                    playerController.moving();

                    if (isRunning == false)
                    {
                        playWalk();
                    }
                    else
                    {
                        playRun();
                    }
                }
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * movementSettings.StrafeSpeed * Mathf.Abs(inputVector.x), 0, 0);
                    playerController.moving();

                    if (isRunning == false)
                    {
                        playWalk();
                    }
                    else
                    {
                        playRun();
                    }
                }
                if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * -movementSettings.StrafeSpeed * Mathf.Abs(inputVector.x), 0, 0);
                    playerController.moving();

                    if (isRunning == false)
                    {
                        playWalk();
                    }
                    else
                    {
                        playRun();
                    }
                }

            }
            //inair
            if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) && !m_IsGrounded && !Wallrunning)
            {
                if (Input.GetAxisRaw("Vertical") > 0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * movementSettings.SpeedInAir * Mathf.Abs(inputVector.z));
                    playerController.Stopmoving();
                    walking.Stop();
                    running.Stop();
                }
                if (Input.GetAxisRaw("Vertical") < -0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * -movementSettings.SpeedInAir * Mathf.Abs(inputVector.z));
                    playerController.Stopmoving();
                    walking.Stop();
                    running.Stop();
                }
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * movementSettings.SpeedInAir * Mathf.Abs(inputVector.x), 0, 0);
                    playerController.Stopmoving();
                    walking.Stop();
                    running.Stop();
                }
                if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * -movementSettings.SpeedInAir * Mathf.Abs(inputVector.x), 0, 0);
                    playerController.Stopmoving();
                    walking.Stop();
                    running.Stop();
                }

            }

            if(Wallrunning == true)
            {
                playWallRun();
            }
            else
            {
                wallRunning.Stop();
            }
        }

        public AudioSource walking;
        public AudioSource running;
        public AudioSource wallRunning;

        private void playWalk()
        {
            //Debug.Log("walk play");


            if (walking.isPlaying == false)
            {
                walking.Play();
            }
        }
        private void stopWalk()
        {
            //Debug.Log("walk stop");

            if (Input.anyKey == false)
            {
                if (walking.isPlaying == true)
                {
                    walking.Stop();
                }
            }
        }

        private void playRun()
        {

            if (running.isPlaying == false)
            {
                running.Play();
            }
        }
        private void stopRun()
        {
            if (Input.anyKey == false)
            {
                if (running.isPlaying == true)
                {
                    running.Stop();
                }
            }
        }

        private void playWallRun()
        {
            if (wallRunning.isPlaying == false)
            {
                wallRunning.Play();
            }
        }
        private void stopWallRun()
        {
            if (wallRunning.isPlaying == true)
            {
                Debug.Log("WALLRUN is playing");
            }
        }

        public void NormalJump()
        {
            m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, m_RigidBody.velocity.z);
            m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
        }
        public void SwitchDirectionJump()
        {
            m_RigidBody.velocity = transform.forward * m_RigidBody.velocity.magnitude;
            m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
        }





        private Vector2 GetInput()
        {

            Vector2 input = new Vector2
            {
                x = Input.GetAxisRaw("Horizontal"),
                y = Input.GetAxisRaw("Vertical")
            };
            movementSettings.UpdateDesiredTargetSpeed(input);
            return input;
        }


        private void RotateView()
        {
            //avoids the mouse looking if the game is effectively paused
            if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

            // get the rotation before it's changed
            float oldYRotation = transform.eulerAngles.y;

            mouseLook.LookRotation(transform, cam.transform);


        }


        /// sphere cast down just beyond the bottom of the capsule to see if the capsule is colliding round the bottom
        private void GroundCheck()
        {
            if (detectGround.Obstruction)
            {
                m_IsGrounded = true;
            }
            else
            {
                m_IsGrounded = false;

            }
        }

        public void Fatigue(bool startStop)
        {
            if (startStop)
            {
                movementSettings.runSpeed /= 2;
                movementSettings.walkSpeed /= 2;
            }
            if (!startStop)
            {
                movementSettings.runSpeed *= 2;
                movementSettings.walkSpeed *= 2;
            }
            movementSettings.ForwardSpeed = movementSettings.runSpeed;
            movementSettings.ForwardSpeed = movementSettings.walkSpeed;
        }
        public void boost(bool startStop)
        {
            if (startStop)
            {
                movementSettings.runSpeed *= 1.5f;
                movementSettings.walkSpeed *= 1.5f;
            }
            if (!startStop)
            {
                movementSettings.runSpeed /= 1.5f;
                movementSettings.walkSpeed /= 1.5f;
            }
            movementSettings.ForwardSpeed = movementSettings.runSpeed;
            movementSettings.ForwardSpeed = movementSettings.walkSpeed;
        }
    }
}
