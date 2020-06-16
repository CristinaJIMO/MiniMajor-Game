using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
//public AudioSource SFX_coin;

    public static int chupetes = 0;

     private void Awake() {

        chupetes = 0;
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {   
            //SFX_coin.Play(); 
            chupetes++;
            GameObject.Destroy(this.gameObject);
        
        }

        
            
        
    }
}
