using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    //private int addScore = 50;

    private void OnCollisionEnter2D(Collision2D player) //Placeholder until I add bullets
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("Collided with the Player");
            health -= 1;

            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
