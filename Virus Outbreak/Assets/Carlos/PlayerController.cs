using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 1f;
    [SerializeField] GameObject dashParticle;

    private float dashReady;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 zeroVelocity = Vector2.zero;
    //private bool dashReady;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashReady = dashCooldown;
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
        dashReady -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        Dash();
    }

    void Dash()
    {
        if(Input.GetKey(KeyCode.Space) && dashReady <= 0)
        {
            Instantiate(dashParticle, transform, false);
            Vector2 dashVelocity = moveVelocity * dashSpeed;
            rb.MovePosition((rb.position + dashVelocity) * Time.deltaTime);
            dashReady = dashCooldown;
            rb.velocity = Vector2.zero;
        }
    }
}
