using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intel : MonoBehaviour
{
    public TextMeshProUGUI intelText;
    public int intel;
    // Start is called before the first frame update
    void Start()
    {
        intel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        intelText.SetText("Intel: " + intel.ToString() + "/3");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Intel")
        {
            intel += 1;
            Destroy(collision.gameObject);
        }
    }
}
