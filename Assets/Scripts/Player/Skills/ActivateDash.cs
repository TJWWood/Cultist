using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDash : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.parent.gameObject.AddComponent<Dash>();
        }
    }
}
