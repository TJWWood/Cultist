using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedObjects : MonoBehaviour
{
    public GameObject painkillers;
    public GameObject steroids;
    public GameObject psychPills;

    public static Dictionary<string, GameObject> medObjDict = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        medObjDict.Add("Painkillers", painkillers);
        medObjDict.Add("Steroids", steroids);
        medObjDict.Add("PsychPills", psychPills);
    }
}
