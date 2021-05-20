using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject Target;
    public Animator anim;
    public float moveSpeed;
    public Rigidbody myRigidbody;
    public Vector3 patrolposition;
    public float stoppedTime;
    public float patrolDistance = 10;
    public float timetowait = 3;
    public float distancetotrigger = 10;
    public float distancetoattack = 3;

    public enum IaState
    {
        Follow,
        Stopped,
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
            case IaState.Follow:
                break;
            case IaState.Patrol:
                break;
            case IaState.Stopped:
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

    void Follow()
    {
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector3.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

    }
}
