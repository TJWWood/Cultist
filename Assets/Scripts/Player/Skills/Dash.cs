using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    float timer;

    bool defenceUpgrade;
    bool damageUpgrade1;
    bool damageUpgrade2;
    GameObject dashAOEParticles;
    // Start is called before the first frame update
    void Start()
    {
        defenceUpgrade = transform.GetChild(2).gameObject.activeSelf;

        damageUpgrade1 = transform.GetChild(3).gameObject.activeSelf;
        damageUpgrade2 = transform.GetChild(4).gameObject.activeSelf;

        dashAOEParticles = transform.GetChild(4).GetChild(0).gameObject;

        timer = 0.08f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            Debug.Log("DASH");
            gameObject.GetComponent<CharacterController>().Move(Camera.main.transform.forward);
            timer -= Time.deltaTime;
        }
        else if(timer <= 0)
        {
            Destroy(gameObject.GetComponent<Dash>());
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Enemy"))
        {
            if(defenceUpgrade)
            {
                Debug.Log("Took no damage");
            }
            else
            {
                Debug.Log("Enemy hits you back");
            }

            if (damageUpgrade1)
            {
                Debug.Log(hit.collider.name + " Hit target for: " + gameObject.GetComponent<PlayerStats>().playerCurrentDamage + " damage");
                if(damageUpgrade2)
                {
                    hit.gameObject.AddComponent<DashAOE>();
                    Instantiate(dashAOEParticles, hit.gameObject.transform, false);
                    Debug.Log("SPIN 2 WIN - HIT ALL ENEMIES AROUND TARGET");
                }
            }
            else
            {
                Debug.Log("Just dashed");
            }

        }
    }
}
