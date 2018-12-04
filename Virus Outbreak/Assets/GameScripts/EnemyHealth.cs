using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int scoreToGive;

    private GameObject player;

    //private int addScore = 50;

    /*private void OnCollisionEnter2D(Collision2D player) //Placeholder until I add bullets
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Collided with the Player");
            health -= 1;

            if (health <= 0)
            {
                Die();
            }
        }
    }
    */

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //print("Enemy " + this.gameObject.name + " has died.");
        Destroy(this.gameObject);

        player.GetComponent<PlayerController>().score += scoreToGive;
        player.GetComponent<PlayerController>().setScoreText();
    }
}
