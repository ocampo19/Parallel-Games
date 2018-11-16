using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private KeyCode moveForward;
    private KeyCode moveBackward;
    private KeyCode moveLeft;
    private KeyCode moveRight;
    [SerializeField] [Range(0, 50)] private float speed = 0;
    // private Rigidbody rb;
    public float projectileVelocity;
    public GameObject projectile;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        moveForward = KeyCode.W;
        moveBackward = KeyCode.S;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
    }

    void Update()
    {
        Movement();

        // check for input from the fire key and make projectiles
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * projectileVelocity * Time.deltaTime);
            Destroy(newProjectile, 1.6f);
        }

        //Screen Wraping
        Vector2 newPosition = transform.position;

        if (transform.position.y > screenTop)
        {
            newPosition.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPosition.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPosition.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPosition.x = screenRight;
        }

        transform.position = newPosition;
    }

    void Movement()
    {
        if (Input.GetKey(moveForward))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(moveBackward))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(moveRight))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        Debug.Log("hit");

        /*
         * Player collides with enemy
         * subtract player life by calling function from Health script
         */


    }
}