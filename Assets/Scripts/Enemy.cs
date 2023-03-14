using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private float thrust = 40f;
    private Rigidbody rb;
    public Transform player;
    float timePassedshot = 0f;
    public GameObject bullet;
    public float speedShot = 10f;
    public Transform bulletSpawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        timePassedshot += Time.deltaTime;
        transform.LookAt(player);
        Vector3 targetLocation = player.position - transform.position;
        float distance = targetLocation.magnitude;                
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust);
        shootdelay();
    }
    void ShootAtPlayer()
    {
        timePassedshot = 0f;
        GameObject instantiatedProjectile;
        instantiatedProjectile = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation) as GameObject;        
        Destroy(instantiatedProjectile, 5);
    }
    void shootdelay()
    {
        if (timePassedshot >= 1.5f)
        {
            ShootAtPlayer();
            timePassedshot = 0f;
        }
    }
}
