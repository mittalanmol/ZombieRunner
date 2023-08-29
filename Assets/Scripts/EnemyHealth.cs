using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float hitpoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;  // Am I dead or not?
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");// We could have use GetComponent bit it's inefficient
                                          // as broadcast function informs every relevant function abt this
        hitpoints -= damage;
        if(hitpoints <= 0)
        {
            Die();
        }

    }
 
    private void Die()
    {
        if (isDead) return;
        isDead = true;  
        GetComponent<Animator>().SetTrigger("die");
    }
}
