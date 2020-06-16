using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    public GameObject CanvasObject;
    public GameObject MainUi;

    public Text Tempo;
    public float tiempo = 0.0f;
    public GameObject CanvasObject2;
    public SceneController SumarPareja;
    public GameObject mybutton;
   
    void Update()
    {
     
        if(!CanvasObject.activeSelf){
        tiempo -= Time.deltaTime;
        }

        Tempo.text = "" + " " + tiempo.ToString ("f0");
       
        // Si te quedas sin tiempo activa el panel de lose
        if (tiempo <= 0) {

            tiempo = 0;  
            CanvasObject2.SetActive(true);
            mybutton.SetActive(false);
        }
    }
}