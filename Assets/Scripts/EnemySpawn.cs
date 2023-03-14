using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawn : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI Timertxt;
    public GameObject expo;
    public GameObject dr1;
    public GameObject dr2;
    public GameObject dr3;
    public GameObject dr4;
    public GameObject dr5;
    void Start()
    {
        TimerOn = true;
        dr1.SetActive(false);
        dr2.SetActive(false);
        dr3.SetActive(false);
        dr4.SetActive(false);
        dr5.SetActive(false);
    }

    
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft < 290)
            {
                expo.SetActive(false);
            }
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);               
            }
            else
            {
                Debug.Log("Time is up");
                TimeLeft = 0;
                TimerOn = false;
                dr1.SetActive(true);
                dr2.SetActive(true);
                dr3.SetActive(true);
                dr4.SetActive(true);
                dr5.SetActive(true);
            }
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        Timertxt.text = string.Format("Time Remaining: {0:00} : {1:00}", minutes, seconds);
    }
}
