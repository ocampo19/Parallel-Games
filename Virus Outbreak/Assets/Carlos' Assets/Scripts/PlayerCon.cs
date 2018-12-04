using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour {

    public float speed = 5f;
    public float dashSpeed = 500f;
    public float dashCooldown = 2f;
    [SerializeField]GameObject dashParticle;

    public float rotationSpeed = 10f;
    public Vector2 direction;
    public Quaternion rotation;
    public float angle;

    private float dashTimer;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector2 dashVelocity;
    private bool dashReady;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTimer = dashCooldown;
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * speed;
        if(dashTimer > 0)
        {
            dashReady = false;
            dashTimer -= Time.fixedDeltaTime;
        }
        if(dashTimer <= 0)
        {
            dashReady = true;
        }

        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + 90;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        Dash();
    }

    void Dash()
    {
        if(Input.GetKey(KeyCode.Space) && dashReady == true)
        {
            Instantiate(dashParticle, rb.position, Quaternion.identity);
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 dashVelocity = moveInput * dashSpeed;
            rb.MovePosition(rb.position + dashVelocity * Time.fixedDeltaTime);
            dashReady = false;
            dashTimer = dashCooldown;
        }
    }
}
