using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFromCultist : MonoBehaviour
{
    public GameObject trail;
    public Transform totem;
    Vector3 target;

    private GameObject loadedTrail;

    void Start()
    {
        float totemHeight = totem.position.y + totem.localScale.y;
        target = new Vector3(totem.position.x, totem.position.y + 2f, totem.position.z);
        loadedTrail = Instantiate(trail, transform, true);
        loadedTrail.transform.localPosition = new Vector3(0f, 1f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        loadedTrail.transform.position = Vector3.MoveTowards(loadedTrail.transform.position, target, 5f * Time.deltaTime);
        if (Vector3.Distance(loadedTrail.transform.position, target) <= 0.01f)
        {
            loadedTrail.transform.position = transform.position;
        }
    }
}
