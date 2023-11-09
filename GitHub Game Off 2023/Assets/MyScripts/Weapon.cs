using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
	public GameObject bulletPrefab;
    public LineRenderer lineRenderer;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot(){
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitInfo){
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, hitInfo.point);
        }

    else
		{
			lineRenderer.SetPosition(0, firePoint.position);
			lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
		}   

        lineRenderer.enabled = true;
        
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

    }
}
