
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera fpsCamera; // we are changing the FOV through Cinemachine as FOV is depending on 
    [SerializeField] float zoomedOutFOV = 42.58f;           // PlayerFollowCamera
    [SerializeField] float zoomedInFOV = 20f;

    bool zoomedInToogle = false;


    private void OnDisable()
    {
        ZoomOut();  // when we turn or change the weapon get the zoom out
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1)) // 1 means right button is clicked
        {
            if(zoomedInToogle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomedInToogle = true;
        fpsCamera.m_Lens.FieldOfView = zoomedInFOV;
    }
    private void ZoomOut()
    {
        zoomedInToogle = false;
        fpsCamera.m_Lens.FieldOfView = zoomedOutFOV;
    }
}
