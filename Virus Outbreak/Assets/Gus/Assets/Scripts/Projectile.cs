using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float projectileVelocity;
    public GameObject projectile;
	
	// Update is called once per frame
	void Update () {
        // check for input from the fire key and make projectiles
        if (Input.GetButtonDown("Fire1")) // Fire1 = left click
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation); // creates a new projectile game object everytime we left click on mouse
            newProjectile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileVelocity * Time.deltaTime); // projectile velocity
            Destroy(newProjectile, 1.6f); // Destroys projectile after 1.6 seconds
        }
    }
}
