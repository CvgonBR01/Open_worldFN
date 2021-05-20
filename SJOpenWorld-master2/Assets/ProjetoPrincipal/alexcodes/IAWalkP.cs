using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAWalkP : MonoBehaviour
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
    public enum IaState
    {
        Stopped,
        Berserk,
        Patrol,
    }

    public IaState currentState;
    // Start is called before the first frame update
    void Start()
    {
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
            case IaState.Berserk:
                Berserk();
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
        //ditancia do jogador for menor q distancetotrigger
        if (Vector3.Distance(transform.position, target.transform.position) < distancetotrigger)
        {
            currentState = IaState.Berserk;
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
    void Berserk()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("Attack", false);
        //se a distancia dele for  menor q 3 ele ataca
        if (Vector3.Distance(transform.position, target.transform.position) < distancetoattack)
        {
            currentState = IaState.Stopped;
        }

        //se a distancia dele for  maior q o trigger ele patrulha de novo 
        if (Vector3.Distance(transform.position, target.transform.position) > distancetotrigger)
        {
            currentState = IaState.Patrol;
        }
    }

   
}

