using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIscript : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float jumpForce;
    public LayerMask groundLayer;
    public float minPlayerY;
    public bool Dead;
    public GameObject projectilePrefab;
    public Transform bulletSpawnPoint;
    public float projectileForce = 500f;
    private Rigidbody2D rb;
    private bool canShoot = true;
    private float collisionCounter = 0f;

    void Start()
    {   
        GameObject target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (collisionCounter > 5f){
            Dead = true;
        }
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        // Check if the player is in range
        float distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < 10f)
        {
            // Fire the projectile
            Fire();
        }

        // Check if there is ground below the AI
        RaycastHit2D groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        if (groundHit.collider != null)
        {
            // Check if the player is on the ground and above a certain y coordinate
            RaycastHit2D playerHit = Physics2D.Raycast(target.transform.position, Vector2.down, 0.6f, groundLayer);
            if (playerHit.collider != null && playerHit.point.y > minPlayerY)
            {
                // Jump towards the player
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
        collisionCounter += 1;
        }
    }

    void Fire()
    {
        if (canShoot)
        {
            // Create a new instance of the projectile prefab at the bulletSpawnPoint position
            GameObject newProjectile = Instantiate(projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

            // Calculate the direction to the player
            Vector2 directionToTarget = (target.transform.position - bulletSpawnPoint.position).normalized;

            // Add a force to the projectile that points towards the player
            rb.AddForce(directionToTarget * projectileForce, ForceMode2D.Impulse);

            // Set canShoot to false and start the cooldown timer
            canShoot = false;
            Invoke(nameof(ResetCooldown), 2f);
        }
    }

    void ResetCooldown()
    {
        canShoot = true;
    }
}