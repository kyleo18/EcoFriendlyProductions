using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public float thrust = 5f;
    private Rigidbody rb;
    public Transform player;
    public Transform player2;
    private bool dragony = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {             
        //transform.LookAt(player);
        Vector3 targetLocation;
        float distance;
        if(dragony)
        {
            transform.LookAt(player);
            targetLocation = player.position - transform.position;
            //distance = targetLocation.magnitude;
        }
        else
        {
            transform.LookAt(player2);
            targetLocation = player2.position - transform.position;
            distance = targetLocation.magnitude;
        }
        distance = targetLocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 0) / 0, 0f, 1f) * thrust);
    }
    //private void OnCollisionEnter(Collision other)
    //{        
    //    if (other.gameObject.tag == "crate")
    //    {
    //        Destroy(other.gameObject);
    //    }       
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "crate")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "dragon")
        {
            dragony = false;
        }
        if (other.gameObject.tag == "creaturecollider")
        {
            SceneManager.LoadScene(sceneBuildIndex: 6);
        }
    }
}
