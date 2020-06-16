using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{
  public AudioSource SFX_move1;
  public AudioSource SFX_move2;
    
  [SerializeField] private SceneController controller;
  [SerializeField] private GameObject Card_Back;

  public void OnMouseDown()
  {
       if(Card_Back.activeSelf && controller.canReveal)
       {
           
            SFX_move1.Play(); // sonido de giro
            Card_Back.SetActive(false); // desactiva la carta girada
            controller.CardRevealed(this);
       }
  }

  private int _id;
  public int id

  {
    get { return _id;}
  }

  public void ChangeSprite(int id, Sprite image)
  {
    _id = id;
    GetComponent<SpriteRenderer>().sprite = image;
  }

  public void Unreveal() // Para voltear las cartas al equivocarse
  {
    SFX_move2.Play();
    Card_Back.SetActive(true);
  }
}
