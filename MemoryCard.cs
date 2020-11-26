using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    public GameObject CardBack;
    [SerializeField] private SceneController controller;
    private int _id;
    public int id {get{return _id;}}
  
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown()
    {
       if(CardBack.activeSelf && controller.canReveal)
        {
            CardBack.SetActive(false);
            controller.CardRevealed(this);
        }

    }

    public void Unreveal()
    {
        CardBack.SetActive(true);
    }
}
