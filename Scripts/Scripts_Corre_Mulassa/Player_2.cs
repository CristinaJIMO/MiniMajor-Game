using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player_2: MonoBehaviour
{   
    private static Player_2 instance;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    //private PolygonCollider2D polygonCollider2D;
    static float moveSpeed = 8f;
    static float jumpvelocity = 13f;
    public AudioSource SFX_point;

    [SerializeField] private LayerMask platformlayerMask;

    public GameObject pre_score;
    public Text Score;
    public Text Score2;

    public GameObject mybutton;

    //data
    private void Awake()
    {
        instance = this;
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        //polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
        moveSpeed = 8f;
        jumpvelocity = 13f;
    }

    private void Update()
    {
        if ( TocandoSuelo() && Input.GetKeyDown(KeyCode.Space))     // saltar PC.
        {
            

            rigidbody2d.velocity = Vector2.up * jumpvelocity;
        }
        
        if ( TocandoSuelo() && Input.touchCount == 1)     // saltar ANDROID.
        {
            rigidbody2d.velocity = Vector2.up * jumpvelocity;
        }
        
        Movimiento();   
        Puntuacion();
    }

    private bool TocandoSuelo()  // comprobar si esta tocando el suelo.
    {
        //RaycastHit2D raycastHit2d = Physics2D.BoxCast(polygonCollider2D.bounds.center, polygonCollider2D.bounds.size, 0f, Vector2.down, 0.2f, platformlayerMask);
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.2f, platformlayerMask);  
        return raycastHit2d.collider != null;
        
    }

    private void Movimiento() 
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow))    // moverse izquierda PC.               
        {
            rigidbody2d.velocity = new Vector2 ( -moveSpeed, rigidbody2d.velocity.y);

        } else {
            
            if (Input.GetKey(KeyCode.RightArrow))   // moverse derecha PC.
            {
               rigidbody2d.velocity = new Vector2 ( +moveSpeed, rigidbody2d.velocity.y); 

            } else {    // no moverse PC 

                rigidbody2d.velocity = new Vector2 ( 0, rigidbody2d.velocity.y);
            }
        }*/
        
        rigidbody2d.velocity = new Vector2 ( +moveSpeed, rigidbody2d.velocity.y);   // Moverse ANDROID.
    
    }

    private void OnTriggerEnter2D(Collider2D collision) {      // Restart si tocas mina o te caes.

         if (collision.tag == "Mine" || collision.tag == "Dead") 
        {
            Player_2.moveSpeed = 0f;
            Player_2.jumpvelocity = 0f;
            int finalScore = LevelGenerator.GetlevelPartCount() + Coin.chupetes - 5;
            pre_score.SetActive(true);
            mybutton.SetActive(false);
        }
    }

    public void Puntuacion() {      // recuento y actualizacion de puntos
        
        int finalScore = LevelGenerator.GetlevelPartCount() + Coin.chupetes - 5;
        Score.text = "" + finalScore;
        Score2.text = "" + finalScore;  
    }
}