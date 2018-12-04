using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShot : MonoBehaviour {

    private GameObject player;

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            player.GetComponent<PlayerController>().bullet = player.GetComponent<PlayerController>().bullet2;
            player.GetComponent<PlayerController>().ammo = 16;
            player.GetComponent<PlayerController>().setAmmoText();
            Destroy(this.gameObject);
        }
    }
}
