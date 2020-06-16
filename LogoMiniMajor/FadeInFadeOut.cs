using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInFadeOut : MonoBehaviour
{

    public Image whiteFade;
    
    private float tiempoRestante = 4;

    // Start is called before the first frame update
    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0.0f);

        FadeIn();

        

        

    }

    void Update() {

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0) {
                       
            SceneManager.LoadScene(1);
            
        }

        
    }

    // Update is called once per frame
    void FadeIn()
    {
        whiteFade.CrossFadeAlpha(1, 2, false);
    }

    
}
