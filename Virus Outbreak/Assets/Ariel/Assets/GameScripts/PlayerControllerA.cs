using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerA : MonoBehaviour {

    public float speed = 20f;
    public Text scoreText;

    private Rigidbody2D rb2d;
    private int score;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        setScoreText();
    }
	
	void FixedUpdate ()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        Vector2 moveVelocity = moveInput * speed;
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.deltaTime);
        //rb2d.AddForce(movement * speed);
	}

    void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
