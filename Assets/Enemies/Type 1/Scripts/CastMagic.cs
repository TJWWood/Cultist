using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastMagic : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("CastMagic");
        Debug.Log("Attacking player");
    }
}
