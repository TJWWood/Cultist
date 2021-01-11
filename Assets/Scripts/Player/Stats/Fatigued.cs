using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Fatigued : MonoBehaviour
{
    // Start is called before the first frame update
    public Volume postProcessingVolume;
    Vignette vignette;
    LensDistortion lensDistortion;
    void Start()
    {
        postProcessingVolume.profile.TryGet<Vignette>(out vignette);
        postProcessingVolume.profile.TryGet<LensDistortion>(out lensDistortion);
    }

    // Update is called once per frame
    void Update()
    {
        //case range for future use
        //case float n when (n >= 50f && n <= 75f):

        //slowly increase intensity of vignette (0 to 1) and lens distortion (0 to -1) based on player fatigue
        vignette.intensity.value = 1.0f - (gameObject.GetComponent<PlayerStats>().playerFatigue / 100);
        lensDistortion.intensity.value = -1.0f + (gameObject.GetComponent<PlayerStats>().playerFatigue / 100);
        if(gameObject.GetComponent<PlayerStats>().playerFatigue <= 0)
        {
            gameObject.GetComponent<PlayerStats>().playerFatigue = 0;
            gameObject.AddComponent<PlayerDie>();
        }
    }
}
