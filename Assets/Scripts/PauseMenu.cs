using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject controls;
    private bool isShowing = false;

    void Update()
    {
        if (Input.GetButtonDown("OptionsButton"))
        {
            isShowing = !isShowing;
            controls.SetActive(isShowing);
        }        
    }//end of update
}//end of script