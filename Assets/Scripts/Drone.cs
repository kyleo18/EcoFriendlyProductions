using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Drone : MonoBehaviour
{   
    private float thrust = 40f;
    private Rigidbody rb;
    public Transform player;
    public GameObject dr1;
    public GameObject dr2;
    public GameObject dr3;
    public GameObject dr4;
    public GameObject dr5;
    public Image marker;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        marker.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.LookAt(player);
        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;
        if(distance > 30)
        {
            marker.gameObject.SetActive(false);
        }
        if(distance <= 30)
        {
            marker.gameObject.SetActive(true);
        }
        if(distance <= 15)
        {
            rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust);
            //dr1.SetActive(true);
            //dr2.SetActive(true);
            //dr3.SetActive(true);
            //dr4.SetActive(true);
            //dr5.SetActive(true);
        }
        //rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust);
    }
}
