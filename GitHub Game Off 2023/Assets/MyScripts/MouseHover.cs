using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public GameObject Highlight;

    public void OnMouseOver(){
        Highlight.SetActive(true);
    }

    public void OnMouseExit(){
        Highlight.SetActive(false);
    }

}
