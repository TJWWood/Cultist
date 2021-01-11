using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Camera cam;
    bool visionActive;

    // Update is called once per frame
    void Update()
    {
        if(!visionActive && Input.GetKeyDown(KeyCode.V))
        {
            cam.gameObject.SetActive(true);
            visionActive = true;
        }
        else if(visionActive && Input.GetKeyDown(KeyCode.V))
        {
            cam.gameObject.SetActive(false);
            visionActive = false;
        }
    }
}
