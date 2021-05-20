using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime_Vermelho : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public Animator anim;
    public Vector3 patrolposition;
    public float stoppedTime;
    public float patrolDistance = 10;
    public float timetowait = 3;
    public float distancetotrigger = 10;
    public float distancetoattack = 3;
    public GameObject SlimeEffect;
    public float SlimeFreq;
    public enum IaState
    {
        Stopped,
        Damage,
        Dying,
        Patrol,
    }

    public IaState currentState;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Lancaslime", 1, SlimeFreq);
        patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case IaState.Stopped:
                Stopped();
                break;
            case IaState.Damage:
                Damage();
                break;
            case IaState.Dying:
                Dying();
                break;
            case IaState.Patrol:
                Patrol();
                break;
        }

        anim.SetFloat("Velocity", agent.velocity.magnitude);
    }

    void Patrol()
    {
        
        agent.isStopped = false;
        agent.SetDestination(patrolposition);
        anim.SetBool("Attack", false);
        //tempo parado
        if (agent.velocity.magnitude < 0.1f)
        {
            stoppedTime += Time.deltaTime;
        }
        //se for mais q timetowait segundos
        if (stoppedTime > timetowait)
        {
            stoppedTime = 0;
            patrolposition = new Vector3(transform.position.x + Random.Range(-patrolDistance, patrolDistance), transform.position.y, transform.position.z + Random.Range(-patrolDistance, patrolDistance));
        }

    }

    void Stopped()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);

        if (target && Vector3.Distance(transform.position, target.transform.position) > distancetotrigger)
        {
            currentState = IaState.Patrol;
        }
    }
    void Damage()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetTrigger("Hit");
        currentState = IaState.Stopped;
    }
    void Dying()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Die", true);
        Destroy(gameObject, 3);
    }

    void Lancaslime()
    {
        GameObject clone = Instantiate(SlimeEffect, gameObject.transform.position, Quaternion.identity);

    }
}

