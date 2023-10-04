using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Drone : MonoBehaviour
{   
    private float thrust = 40f;
    private Rigidbody rb;
    public Transform player;
    //public Image marker;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //marker.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;
        if(distance > 30)
        {
            //marker.gameObject.SetActive(false);
        }
        if(distance <= 30)
        {
            //marker.gameObject.SetActive(true);
        }       
        if(distance <= 20)
        {
            //SceneManager.LoadScene(sceneBuildIndex: 6);
        }
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
}
