using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerAssets : MonoBehaviour
{
    int health;
    int maxhealth = 100;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(health.ToString());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("yepI");
            health -= 20;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Finish")
        {

        }
    }
}
