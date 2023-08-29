using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float chaserange = 5f;
    [SerializeField] float turnspeed = 5f;
    bool isProvoked = false;
    EnemyHealth health;
    Transform target;

    NavMeshAgent navmeshagent;
    float distancetotarget = Mathf.Infinity;

     void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
        health= GetComponent<EnemyHealth>();
        target=FindObjectOfType<PlayerHealth>().transform;//Find the player than find the player tranform. This is where the target is
    }

    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navmeshagent.enabled = false;
        }
        distancetotarget = Vector3.Distance(target.position, transform.position);

        if(isProvoked)
        {
            Engagetarget();
        }

        else if(distancetotarget <= chaserange)
        { 
            isProvoked = true;
            
        }
    }
    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void Engagetarget()
    {
        FaceTarget();
        if(distancetotarget>= navmeshagent.stoppingDistance)
        {
            Chasetarget();
        }

        if(distancetotarget<=navmeshagent.stoppingDistance)
        {
            Attacktarget();
        }
            
    }

    private void Chasetarget()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");//move is variable name we have assign in animation tool
        //this will make the enemy to chase the player where it is present
        navmeshagent.SetDestination(target.position);
    }

    private void Attacktarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        Debug.Log("Attack Attack Attack");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0 , direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookrotation,Time.deltaTime*turnspeed);
        //transform.rotation , where the target is ,  we need to rotate at a certain speed
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        // here our explosionRadius is chaserange
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaserange);
    }
}
