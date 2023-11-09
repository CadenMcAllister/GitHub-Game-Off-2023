using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool IsScaleable = true;
    public bool IsScaled = false;
    public Weapon weapon;
    public GameObject ResizerRay;

    void Start(){
        weapon = ResizerRay.GetComponent<Weapon>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        if (IsScaleable){
            if (weapon.currentGun.tag == "2x"){
                transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z);
            }
        }
    }    

}
