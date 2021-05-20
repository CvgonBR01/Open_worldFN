using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class boss : MonoBehaviour 
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject minion;
    public GameObject projetil;
    public Animator anim;
    public Transform enemypos;
    public Vector3 patrolposition;
    public float stoppedTime;
    public float patrolDistance = 10;
    public float timetowait = 3;
    public float distancetotrigger = 10;
    public float distancetoattack = 3;
    public float ShotFreq;
    //public GameObject player;
    public float speed;
    
    public Transform spawnPosition;
    Vector3 randomLocation;
    public enum IaState
    {
        Stopped,
        Summon,
        Shot,
        AttackMelee,
        Damage,
        Dying,
        Patrol,
        Debuff,
    }

    public IaState currentState;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos = new Vector3(target.transform.position.x, target.transform.position.y + 1, 
                                        target.transform.position.z);
        transform.rotation = Quaternion.LookRotation(playerPos);
        InvokeRepeating("Shot", 3, ShotFreq);
        currentState = IaState.Shot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        if (!GameObject.FindGameObjectWithTag("Minion"))
        {
            Summon();

        }


        switch (currentState)
        {
            case IaState.Stopped:
                Stopped();
                break;
            case IaState.Summon:
                Summon();
                break;
            case IaState.Shot:
                Shot();
                break;
            case IaState.AttackMelee:
                AttackMelee();
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
            case IaState.Debuff:
                Debuff();
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
            currentState = IaState.AttackMelee;
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
    void Summon()
    {


        GameObject clone = (GameObject)Instantiate(minion, enemypos.position, enemypos.rotation);
        clone.tag = "Minion";

    }


    void Shot() 
    {
        float distance = Vector3.Distance(agent.transform.position, target.transform.position);
        float minAttackDistance = 1.5f;
      if (distance > minAttackDistance)
        {     
            GameObject clone = Instantiate(projetil, target.transform.position, Quaternion.identity);
            
        }

        if (distance < minAttackDistance)
        {
            currentState = IaState.AttackMelee;
        }

    }

    void AttackMelee()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", true);
        agent.SetDestination(target.transform.position);
        //se o jogador se afastar ele volta a atirar
        if (Vector3.Distance(transform.position, target.transform.position) > distancetoattack + 2)
        {
            currentState = IaState.Shot;
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

    void Debuff()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Die", true);
        Destroy(gameObject, 3f);
    }

}