using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 20f;
    public Text scoreText;
    public int score;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bulletSpawnPoint;
    public Text ammoText;
    public int ammo;
    public GameObject temp;

    private Transform bulletSpawned;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        setScoreText();
        ammo = 999;
        setAmmoText();
        temp = bullet;
    }

    void Update ()
    {
        // 360 degree aim
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 7f * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            ammo--;
            setAmmoText();
            if (ammo == 0)
            {
                bullet = temp;
                ammo = 999;
                setAmmoText();
            }
        }
    }
	
	void FixedUpdate ()
    {
        // Player movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));        
        Vector2 moveVelocity = moveInput * speed;
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.deltaTime);      
	}

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

    public void setScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void setAmmoText()
    {
        ammoText.text = ammo.ToString();
    }
}
