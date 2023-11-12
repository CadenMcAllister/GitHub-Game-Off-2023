using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;
	public GameObject impactEffect;

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
        /*
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
        */
        if (!hitInfo.CompareTag("Enemy")){
		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
        }
	}
}
