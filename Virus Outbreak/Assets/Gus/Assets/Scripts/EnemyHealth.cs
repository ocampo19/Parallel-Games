using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Projectile(Clone)")
        {
            health--;
            Destroy(collision.gameObject); // this destroys projectile

            if (health == 0)
            {
                // Call CreateItemDrop from ItemDrop class
                ItemDrop drop = gameObject.GetComponent<ItemDrop>();
                drop.CreateItemDrop(); // calls CreateItemDrop() from ItemDrop class

                Destroy(gameObject);  // this destroys the enemy
            }
            
        }
    }
}
