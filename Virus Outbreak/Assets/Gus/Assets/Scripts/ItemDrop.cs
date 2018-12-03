using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {

    public GameObject ExtraLife;
    public GameObject Projectile_orange;
    public GameObject Projectile_blue;

    // Generate a random number between two numbers
    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        int randomNum = random.Next(min, max);
        Debug.Log("randomNum = " + randomNum);
        return randomNum;
    }

    public void CreateItemDrop()
    {
        int generateRandNum = RandomNumber(1, 10);

        if (generateRandNum == 3)
        {
            GameObject newItemDrop = Instantiate(ExtraLife, transform.position, transform.rotation);  // create a new itemDrop game object
            Destroy(newItemDrop, 6f); // Destroys itemDrop after 6 seconds if player does not pick up item
        }
        
        if (generateRandNum == 6)
        {
            GameObject newItemDrop1 = Instantiate(Projectile_orange, transform.position, transform.rotation);
            Destroy(newItemDrop1, 6f);
        }

        if (generateRandNum == 9)
        {
            GameObject newItemDrop2 = Instantiate(Projectile_blue, transform.position, transform.rotation);
            Destroy(newItemDrop2, 6f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("I'm " + gameObject);
        if (collision.gameObject.name == "Player")
        {
            if (gameObject.name == "Projectile_orange(Clone)")
            {
                Debug.Log("orange power up!");
            }
            if (gameObject.name == "Projectile_blue(Clone)")
            {
                Debug.Log("blue power up!");
            }
            if (gameObject.name == "ExtraLife(Clone)")
            {
                Debug.Log("life power up!");
            }
            Destroy(gameObject); // this destroys power-up game object
        }

    }
}
