using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;  //will be able to access the Health component as it's type playerhealth that we require
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();  // initialising it in start so we can easily use target function in rest 
    }                                                //  it just happening once that we're finding the type   

    public void AttackHitEvent()
    {
        if (target == null) 
        {
            return;        
        }
        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }
}
