using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform bulletSpawnPoint;
    public float projectileForce = 10f;
    private GameObject currentGun;
    

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        currentGun = gameObject;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

void Fire()
{
    GameObject newProjectile = Instantiate(currentGun.GetComponent<GunController>().projectilePrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();    
    
    rb.AddForce(transform.right * currentGun.GetComponent<GunController>().projectileForce, ForceMode2D.Impulse);

    Destroy(newProjectile, 5f);
}


}
