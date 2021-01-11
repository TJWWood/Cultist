using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAOE : MonoBehaviour
{
    void Start()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.5f);

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("AOE HIT ENEMY: " + hitCollider.gameObject.name);
            }
        }
        Destroy(gameObject.GetComponent<DashAOE>());   
    }
}
