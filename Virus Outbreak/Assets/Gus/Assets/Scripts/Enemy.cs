using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float maxThrust;
    public float maxSpin;
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    // Use this for initialization
    void Start () {
        //Add a random amount of spin and thrust to the enemy
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float spin = Random.Range(-maxSpin, maxSpin);

        rb.AddForce(thrust);
        rb.AddTorque(spin);
	}
	
	// Update is called once per frame
	void Update () {
        //Screen Wraping
        Vector2 newPosition = transform.position;

        if(transform.position.y > screenTop)
        {
            newPosition.y = screenBottom;
        }
        if(transform.position.y < screenBottom)
        {
            newPosition.y = screenTop;
        }
        if(transform.position.x > screenRight)
        {
            newPosition.x = screenLeft;
        }
        if(transform.position.x < screenLeft)
        {
            newPosition.x = screenRight;
        }

        transform.position = newPosition;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemy collides with 'collision' variable
        //Debug.Log("Hit by " + collision.name);

        if(collision.gameObject.name == "Projectile(Clone)")
        {
            Destroy(gameObject);           // this destroys the enemy
            Destroy(collision.gameObject); // this destroys projectile
            /*
             * Add 100 points to the score for destroying an enemy
             * 
             * 
             * TESTING!!!!!!!!!
             */
        }
    }
}
