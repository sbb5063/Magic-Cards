using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuttons : MonoBehaviour
{
    public GameObject targetobject;
    public string targetmessage;
    private Color highlightcolor = Color.cyan;
   
    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = highlightcolor;
        }
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite != null)
        {
            sprite.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
       
    }

    public void OnMouseUp()
    {
        transform.localScale =  new Vector3(0.2f, 0.2f, 0.2f);
        if(targetobject != null)
        {
            targetobject.SendMessage(targetmessage);
        }
    }
}
