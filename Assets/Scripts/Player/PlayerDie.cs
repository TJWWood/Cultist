using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject);
        Debug.LogError("you passed out, fatigued");
    }
}
