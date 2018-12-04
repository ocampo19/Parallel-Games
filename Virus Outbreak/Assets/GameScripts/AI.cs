using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    EnemyHealth enemyHealth;        // Reference to this enemy's health.
    Transform enemy;
    NavMeshAgent nav;


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("enemy").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        nav.Warp(enemy.position);
    }


    void Update()
    {

        if (enemyHealth.health > 0 && playerHealth.health > 0)
        {


            nav.Warp(enemy.position);
            nav.SetDestination(player.position);


        }
        else
        {
            nav.enabled = false;
        }
    }
}