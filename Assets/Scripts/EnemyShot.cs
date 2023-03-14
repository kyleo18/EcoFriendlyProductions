using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float force;
    [SerializeField] private float rotationForce;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 direction = target.position - rb.position;
        direction.Normalize();
        Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotationAmount * rotationForce;
        rb.velocity = transform.forward * rotationForce;
    }
}
