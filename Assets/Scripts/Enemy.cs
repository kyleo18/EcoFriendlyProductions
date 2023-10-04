using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    private float thrust = 40f;
    private Rigidbody rb;
    public Transform player;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {     
        transform.LookAt(player);
        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 0) / 500, 0f, 1f) * thrust);        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="creaturecollider")
        {
            SceneManager.LoadScene(sceneBuildIndex: 6);
        }       
    }
}
