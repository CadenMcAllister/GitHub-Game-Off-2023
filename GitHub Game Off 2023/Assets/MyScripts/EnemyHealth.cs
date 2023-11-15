using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float collisionCounter = 0;
    public GameObject Enemy;
    public GameObject DeathEffect;
    void Update(){

        if (collisionCounter > 2){
            Instantiate(DeathEffect, transform.position, transform.rotation);
            Destroy(Enemy, 2f);
        }

    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
        collisionCounter += 1;
        }
    }
}
