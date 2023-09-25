using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreenOptions : MonoBehaviour
{
    public GameObject setting;
    public bool isSettingActive = false;
    public GameObject player;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (isSettingActive == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }
    public void Pause()
    {
        setting.SetActive(true);
        isSettingActive = true;
        //player.GetComponent<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        setting.SetActive(false);
        isSettingActive = false;
        //player.GetComponent<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
