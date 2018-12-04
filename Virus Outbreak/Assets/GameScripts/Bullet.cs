using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float maxDistance;
    //public float damage;

    private GameObject triggeringEnemy;

	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        maxDistance += 1 * Time.deltaTime;

        if (maxDistance >= 3)
            Destroy(this.gameObject);
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<EnemyHealth>().health -= 1;
            Destroy(this.gameObject);
        }

        if (other.gameObject.name == "Background")
        {
            Destroy(this.gameObject);
        }
    }
}
