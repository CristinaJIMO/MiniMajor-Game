using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  public float speed = 1f;
  public float mapLimit = 0f;
  private Rigidbody2D rb;
  
  public Text Vidas;
  public float NumeroVidas = 3;

  public AudioSource SFX_fuego;
  public AudioSource SFX_agua;

  public GameObject panel_win;

  public GameObject mybutton;

  void Start () {

    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate () {   //mejor para hacer fisicas

    Vector3 characterScale = transform.localScale;

    float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;      //movimiento horizontal

    Vector2 newPosition = rb.position + Vector2.right * x;

    newPosition.x = Mathf.Clamp(newPosition.x, -mapLimit, mapLimit);

    if(Input.GetAxis("Horizontal") < 0) 
    {
      characterScale.x= -0.8f;
    }

    if(Input.GetAxis("Horizontal") > 0) 
    {
      characterScale.x= 0.8f;
    }

    transform.localScale = characterScale;

    rb.MovePosition(newPosition);        //moveposition--> mueve el rigidbody y comprueba si colisiona con algo. // rb.position para coger la posicion actual, el * x para poder ir a la izquierda.
    
    if (panel_win.activeSelf) {   // si se acaba la partida destruye los items

      Destroy(GameObject.Find("Cubo(Clone)"));
      Destroy(GameObject.Find("Fuego(Clone)"));
    }
  }

  void OnCollisionEnter2D (Collision2D col) {

  if(col.gameObject.name == "Cubo(Clone)") {

    NumeroVidas--;

    Vidas.text = "" + NumeroVidas;

    SFX_agua.Play();
      
    Destroy(col.gameObject);

    if (NumeroVidas <= 0) {

    panel_win.SetActive(true);
    mybutton.SetActive(false);

  }
     
  }

  if(col.gameObject.name == "Fuego(Clone)")
    
  {
    if(NumeroVidas <= 2) {

      NumeroVidas++;

          
      Vidas.text = "" + NumeroVidas;

      SFX_fuego.Play();

      Destroy(col.gameObject);
    }

   SFX_fuego.Play();

   Destroy(col.gameObject);

  }
  
  }
  
}

