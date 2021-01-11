using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseTotem : MonoBehaviour
{
    public GameObject totem;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(totem, transform);
    }
}
