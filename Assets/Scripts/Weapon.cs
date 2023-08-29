using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FpCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;// Damage of a gun
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject hiteffect;
    [SerializeField] float timebetweenShots = 0.6f; // makes delay between 
                           
    [SerializeField] Ammo ammoslot; //connecting ammoscript with weapon how much ammo we have at the moment
    [SerializeField] AmmoType ammoType; // type of ammo we use

    [SerializeField] TextMeshProUGUI ammoText;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;  // to remove the delay where we can't use shotgun after switching
    }
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoslot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
    IEnumerator Shoot()
    {
        canShoot = false;//wed can't fire off any more co routines 
        if (ammoslot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleflash();
            processRaycast();
            ammoslot.ReduceCurrentAmmo(ammoType);
        }
            yield return new WaitForSeconds(timebetweenShots);
            canShoot=true;
    }

    private void PlayMuzzleflash() //It generates the effect when we shoot
    {
        muzzleflash.Play();
    }

    private void processRaycast()
    {
        RaycastHit hit;// it will store the info abt what we hit

        //it's like a bool func and return whether we hit or not on the basis of info we provided
        //FpCamera.transform.position give info where our camera is initially
        //FpCamera.transform.forward give info abt forward direction

        if (Physics.Raycast(FpCamera.transform.position, FpCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit the thing " + hit.transform.name);
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) // We hit something but it's not enemy so it will not try to destroy it
            {
                return;
            }
            // Calling the enemy health that decreases the enemy's 
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1 );
    }
}
