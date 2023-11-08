using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class PopupText : MonoBehaviour
{


    public GameObject popUp, popZone, removeZone;

    public float timeAdd, timeRemove;

    public bool triggered = false;

    // 0 = add on a zone trigger | 1 = add after time |
    public int popMode;

    // 0 = remove on a zone trigger | 1 = remove after time after appearing
    public int removeMode;

    //public GameObject dialogueObject;

    public AudioSource thisSource, playerSource;

    // Start is called before the first frame update
    void Start()
    {
        playerSource = GameObject.Find("Dialogue Audio").gameObject.GetComponent<AudioSource>();
        thisSource = popUp.transform.Find("1").GetComponent<AudioSource>();

        Debug.Log(thisSource.clip);

        if (popMode == 1)
        {
            Invoke("AddPopUp", timeAdd);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    void AddPopUp()
    {
        if (!triggered)
        {

            foreach (Transform child in popUp.transform.parent.transform)
            {
                if (child.gameObject != popUp)
                {
                    child.gameObject.SetActive(false);
                }
            }


            popUp.SetActive(true);
            //Debug.Log("trigger");
            playerSource.clip = thisSource.clip;
            playerSource.Play();




            if (removeMode == 1)
            {
                Invoke("RemovePopUp", timeRemove);
            }

            triggered = true;
        }



    }

    void RemovePopUp()
    {
        popUp.SetActive(false);
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerController")
        {
            AddPopUp();
        }
    }
}
