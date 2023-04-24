using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intel : MonoBehaviour
{
    public TextMeshProUGUI intelText;
    public int intel;
    public GameObject extract;
    public Image f1;
    public Image f2;
    public Image f3;
    public Image c1;
    public Image c2;
    public Image c3;
    // Start is called before the first frame update
    void Start()
    {
        intel = 0;
        extract.SetActive(false);
        c1.gameObject.SetActive(false);
        c2.gameObject.SetActive(false);
        c3.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if (intel >= 3)
        {
            extract.SetActive(true);
        }
        if(intel >= 1)
        {
            c1.gameObject.SetActive(true);
            f1.gameObject.SetActive(false);
        }
        if (intel >= 2)
        {
            c2.gameObject.SetActive(true);
            f2.gameObject.SetActive(false);
        }
        if (intel >= 3)
        {
            c3.gameObject.SetActive(true);
            f3.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Intel")
        {
            intel += 1;
            Destroy(collision.gameObject);
        }
        //if(collision.gameObject.tag == "Finish" && intel == 3)
        //{
        //    SceneManager.LoadScene(sceneBuildIndex: 5);
        //}
    }
}
