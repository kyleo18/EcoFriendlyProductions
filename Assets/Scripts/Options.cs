using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    //Set the Mouse Sensitivity
    //public Slider slider;
    //public float mouseSensitivity = 100f;

    //private void Start()
    //{
    //    mouseSensitivity = PlayerPrefs.GetFloat("currrentSensitivity", 100);
    //    slider.value = mouseSensitivity / 10;
    //    //Cursor.lockState = CursorLockMode.Locked;
    //}
    //public void AdjustSpeed(float newSpeed)
    //{
    //    mouseSensitivity = newSpeed * 10;
    //}

    //Set the Volume
    public AudioMixer masterMixer;
    public void SetVolume(float volume)
    {
        masterMixer.SetFloat("masterVolume", volume);
    }
}
