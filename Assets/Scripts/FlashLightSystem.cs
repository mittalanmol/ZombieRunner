using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();//accessing the Light component of inspector
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle<=minimumAngle)
        {
            return;
        }
        else
        {
           myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
     
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay *Time.deltaTime;
    }

}   
