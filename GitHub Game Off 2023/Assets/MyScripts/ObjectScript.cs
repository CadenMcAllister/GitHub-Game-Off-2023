using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool IsScaleable = true;
    public bool IsScaled = false;
    public Weapon weapon;
    public GameObject ResizerRay;
    private Vector3 originalScale;
    private Dictionary<string, float> scaleFactors = new Dictionary<string, float>
    {
        {"RayGun_2X", 2f},
        {"RayGun_5X", 5f},
        {"RayGun_Half", 0.5f},
        {"RayGun_1X", 1f}, // Added 1X scale
        // Add more scale types here
    };

    void Start(){
        weapon = ResizerRay.GetComponent<Weapon>();
        originalScale = transform.localScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerProjectile")){
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        if (IsScaleable){
            string spriteName = ResizerRay.GetComponent<SpriteRenderer>().sprite.name;
            if (scaleFactors.ContainsKey(spriteName)){
                float scaleFactor = scaleFactors[spriteName];
                transform.localScale = new Vector3(originalScale.x * scaleFactor, originalScale.y * scaleFactor, originalScale.z);
                IsScaled = true;
            }
            else if (IsScaled){
                transform.localScale = originalScale;
                IsScaled = false;
            }
        }
        }
    }    
}

