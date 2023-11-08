using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            gameObject.SetActive(true);
            StartCoroutine("EffectCoroutine");
            gameObject.SetActive(false);
        }

    }

    IEnumerator EffectCoroutine(){
        yield return new WaitForSeconds(1);
    }
}

