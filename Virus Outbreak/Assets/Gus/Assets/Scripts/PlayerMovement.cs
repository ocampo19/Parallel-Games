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

    // variables are used for screen wrapping
    public float screenTop;       // top edge of screen before game objects are out of camera view
    public float screenBottom;   // bottom edge
    public float screenLeft;    // left edge
    public float screenRight;  // right edge

    void Awake()
    {
        moveForward = KeyCode.W;
        moveBackward = KeyCode.S;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
    }

    void Update()
    {
        Movement();

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
}