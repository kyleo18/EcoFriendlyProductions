using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHealth(float health)
    {
        healthslider.value = health;
    }
    public void SetMaxHealth(float health)
    {
        healthslider.maxValue = health;
        healthslider.value = health;
    }
}
