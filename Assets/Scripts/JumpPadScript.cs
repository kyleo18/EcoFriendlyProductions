using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScript : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpAmount = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bouncePad")
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }
}
