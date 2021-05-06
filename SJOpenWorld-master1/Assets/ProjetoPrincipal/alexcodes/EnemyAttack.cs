using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float timeBetweenAttacks = 0.5f;
    public float minAttackDistance = 1.5f;
    public float distance;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    //PlayerHealth playerHealth;
   // EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       // playerHealth = player.GetComponent<PlayerHealth>();
       // enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }*/




    void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (timer >= timeBetweenAttacks && distance <10 /*&& enemyHealth.currentHealth > 0*/)
        {
            Attack();
        }
        /*
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }*/
    }


    void Attack()
    {
        timer = 0f;

       // anim.SetBool("Attack", true);
       if (distance < minAttackDistance)
        {
            anim.SetBool("Attack", true);
        }
    }

}
