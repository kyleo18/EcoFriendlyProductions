using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerAssets : MonoBehaviour
{
    public PlayerController pc;

    public AudioSource walking;
    public AudioSource running;
    public AudioSource breathRunning;
    public AudioSource breathWithdrawl;

    // Update is called once per frame
    void Update()
    {

            //SceneManager.LoadScene(sceneBuildIndex: 6);


        if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0)
        {
            //playWalk();

            running.Stop();
            breathRunning.Stop();
            //if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0f && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude < 6f)
            //{
            //    walking.Play();
            //    running.Stop();
            //    breathRunning.Stop();
            //}

                //else if (this.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 6f)
                //{
                //    walking.Stop();
                //    running.Play();
                //    breathRunning.Play();
                //}

            //else
            //{
            //    walking.Stop();
            //    running.Stop();
            //    breathRunning.Stop();
            //}

        }

        if (pc.doWithdrawalEffects == true)
        {
            breathWithdrawl.Play();
        }
        else
        {
            breathWithdrawl.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("yepI");
            Destroy(collision.gameObject);

        }
        
    }


    private void playWalk()
    {
        Debug.Log("walk play");

        
        if (walking.isPlaying == false)
        {
            walking.Play();
        }
    }

    
}
