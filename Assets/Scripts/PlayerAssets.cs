using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerAssets : MonoBehaviour
{
    int health;
    int maxhealth = 100;
    public TextMeshProUGUI healthText;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthBar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(health.ToString() + "/100");
        if (health <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 6);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("yepI");
            health -= 20;
            Destroy(collision.gameObject);
            healthBar.SetHealth(health);
        }
        
    }
}
