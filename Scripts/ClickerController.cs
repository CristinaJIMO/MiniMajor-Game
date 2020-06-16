using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickerController : MonoBehaviour
{

    public GameObject[] objetos = new GameObject[5];
    private float tiempoMaximo = 3; // tiempo en segundos que se activa cada caja
    private float tiempoRestante; // el tiempo que aún estará activa la caja actual
    private int indObjectoActivo;  // el índice de la caja activa
    private Ray ray;
    private RaycastHit hit;


    public float puntuacion = 0;
    private float puntos = 0;
    public Text textocontador;

    private float puntuacionmuerte = 3;
    private float puntosmuerte = 3;
    public Text textocontadormuerte;

    public Sprite Activo;
    public Sprite Inactivo;
    
    public GameObject baile;
    public Sprite derinf;
    public Sprite dersup;
    public Sprite izqinf;
    public Sprite izqsup;
    public Sprite arriba;
    public Sprite normal;

    public GameObject CanvasDerrota;
    public Text CanvasFinal;

    public Button BotonPause;
    public Button BotonPlay;
    public Button VolverMenu;
    public Button VolverFinal;
    
    public AudioSource myAudio;
    public AudioClip clip;
    public AudioClip check;
    public AudioClip wrong;
    
    public GameObject mybutton;
    
    

    void Start()
    {
        Time.timeScale = 1;
        ActivaCajaAlAzar();
        RestauraTiempo();    
        Button btnpause = BotonPause.GetComponent<Button>();
        btnpause.onClick.AddListener(ParaTiempo); 

        Button btnplay = BotonPlay.GetComponent<Button>();
        btnplay.onClick.AddListener(SigueTiempo);   

        Button btnmenu = VolverMenu.GetComponent<Button>();
        btnmenu.onClick.AddListener(SigueTiempo);  
        
        Button btnfinal = VolverFinal.GetComponent<Button>();
        btnfinal.onClick.AddListener(SigueTiempo);  

        myAudio = GetComponent<AudioSource>();
        
              
    }
    
    void Update()
    {

        // raycast para detectar si se pulsa sobre la caja activa 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject == objetos[0]) {
                if((objetos[indObjectoActivo] == objetos[0])) {
                    AudioSource.PlayClipAtPoint(check, new Vector3(0,0,0));
                    puntos = puntuacion++;
                    if(puntuacion >= 10) {
                        tiempoMaximo = 2;
                    }
                    if(puntuacion >= 20) {
                        tiempoMaximo = 1;
                    }
                    if(puntuacion >= 30) {
                        tiempoMaximo = 0.75f;
                    }
                    if(puntuacion >= 40) {
                        tiempoMaximo = 0.5f;
                    }
                    if(puntuacion >= 100) {
                        tiempoMaximo = 0.2f;
                    }
                    textocontador.text = "" + puntuacion;
                    baile.GetComponent<Image>().sprite = arriba;
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();

                } else {
                    puntosmuerte = puntuacionmuerte --;
                    textocontadormuerte.text = "" + puntuacionmuerte;
                    
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();
                    
                    if(puntuacionmuerte <= 0) {
                        Muerte();
                    } else {
                        AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
                    } 
                }     
            }    
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject == objetos[1]) {
                if((objetos[indObjectoActivo] == objetos[1])) {
                    AudioSource.PlayClipAtPoint(check, new Vector3(0,0,0));
                    puntos = puntuacion++;
                    if(puntuacion >= 10) {
                        tiempoMaximo = 2;
                    }
                    if(puntuacion >= 20) {
                        tiempoMaximo = 1;
                    }
                    if(puntuacion >= 30) {
                        tiempoMaximo = 0.75f;
                    }
                    if(puntuacion >= 40) {
                        tiempoMaximo = 0.5f;
                    }
                    if(puntuacion >= 100) {
                        tiempoMaximo = 0.2f;
                    }
                    textocontador.text = "" + puntuacion;
                    baile.GetComponent<Image>().sprite = dersup;
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();

                } else {
                    puntosmuerte = puntuacionmuerte --;
                    textocontadormuerte.text = "" + puntuacionmuerte;
                    
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();
                    
                    if(puntuacionmuerte <= 0) {
                        Muerte();
                    } else {
                        AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
                    } 
                }     
            }    
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject == objetos[2]) {
                if((objetos[indObjectoActivo] == objetos[2])) {
                    AudioSource.PlayClipAtPoint(check, new Vector3(0,0,0));
                    puntos = puntuacion++;
                    if(puntuacion >= 10) {
                        tiempoMaximo = 2;
                    }
                    if(puntuacion >= 20) {
                        tiempoMaximo = 1;
                    }
                    if(puntuacion >= 30) {
                        tiempoMaximo = 0.75f;
                    }
                    if(puntuacion >= 40) {
                        tiempoMaximo = 0.5f;
                    }
                    if(puntuacion >= 100) {
                        tiempoMaximo = 0.2f;
                    }
                    textocontador.text = "" + puntuacion;
                    baile.GetComponent<Image>().sprite = derinf;
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();

                } else {
                    puntosmuerte = puntuacionmuerte --;
                    textocontadormuerte.text = "" + puntuacionmuerte;
                    
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();
                    
                    if(puntuacionmuerte <= 0) {
                        Muerte();
                    } else {
                        AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
                    } 
                }     
            }    
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject == objetos[3]) {
                if((objetos[indObjectoActivo] == objetos[3])) {
                    AudioSource.PlayClipAtPoint(check, new Vector3(0,0,0));
                    puntos = puntuacion++;
                    if(puntuacion >= 10) {
                        tiempoMaximo = 2;
                    }
                    if(puntuacion >= 20) {
                        tiempoMaximo = 1;
                    }
                    if(puntuacion >= 30) {
                        tiempoMaximo = 0.75f;
                    }
                    if(puntuacion >= 40) {
                        tiempoMaximo = 0.5f;
                    }
                    if(puntuacion >= 100) {
                        tiempoMaximo = 0.2f;
                    }
                    textocontador.text = "" + puntuacion;
                    baile.GetComponent<Image>().sprite = izqinf;
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();

                } else {
                    puntosmuerte = puntuacionmuerte --;
                    textocontadormuerte.text = "" + puntuacionmuerte;
                    
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();
                    
                    if(puntuacionmuerte <= 0) {
                        Muerte();
                    } else {
                        AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
                    } 
                }     
            }    
        }
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButtonDown(0) && hit.transform.gameObject == objetos[4]) {
                if((objetos[indObjectoActivo] == objetos[4])) {
                    AudioSource.PlayClipAtPoint(check, new Vector3(0,0,0));
                    puntos = puntuacion++;
                    if(puntuacion >= 10) {
                        tiempoMaximo = 2;
                    }
                    if(puntuacion >= 20) {
                        tiempoMaximo = 1;
                    }
                    if(puntuacion >= 30) {
                        tiempoMaximo = 0.75f;
                    }
                    if(puntuacion >= 40) {
                        tiempoMaximo = 0.5f;
                    }
                    if(puntuacion >= 100) {
                        tiempoMaximo = 0.2f;
                    }
                    textocontador.text = "" + puntuacion;
                    baile.GetComponent<Image>().sprite = dersup;
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();

                } else {
                    puntosmuerte = puntuacionmuerte --;
                    textocontadormuerte.text = "" + puntuacionmuerte;
    
                    DesactivaCaja();
                    ActivaCajaAlAzar();
                    RestauraTiempo();
                    
                    if(puntuacionmuerte <= 0) {
                        Muerte();
                    } else {
                        AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
                    } 
                }     
            }    
        }

        // actualizamos el tiempo que aún le queda a la caja como activa
        tiempoRestante = tiempoRestante - Time.deltaTime;
        
        // comprobamos si se ha acabado el tiempo de la caja activa
        if (tiempoRestante <= 0) {
            
            textocontador.text = "" + puntuacion;
            puntosmuerte = puntuacionmuerte --;
            textocontadormuerte.text = "" + puntuacionmuerte;
            DesactivaCaja();
            ActivaCajaAlAzar();
            RestauraTiempo();
                    
            if(puntuacionmuerte <= 0) {                    
                Muerte();
            } else {
                AudioSource.PlayClipAtPoint(wrong, new Vector3(0,0,0));
            }                              
        }

        // Mostramos la puntuación
        Debug.Log("Puntuacion: " + puntuacion);
    }

    void ActivaCajaAlAzar() {
        // cogemos una caja al azar, evitando únicamente que la nueva caja activada sea la misma que la anterior
        float previo = indObjectoActivo;
        while (previo == indObjectoActivo) {
            indObjectoActivo = Random.Range(0, objetos.Length);
        }
        objetos[indObjectoActivo].GetComponent<SpriteRenderer>().sprite = Activo;
    }

    void DesactivaCaja() {
        objetos[indObjectoActivo].GetComponent<SpriteRenderer>().sprite = Inactivo;
    }

    void RestauraTiempo() {
        tiempoRestante = tiempoMaximo;
    }
    
    void ParaTiempo(){
        Time.timeScale = 0;
    }

    void SigueTiempo(){
        Time.timeScale = 1;
    }

    void Muerte() {
        Time.timeScale = 0;
        AudioSource.PlayClipAtPoint(clip, new Vector3(0,0,0));
        CanvasDerrota.SetActive(true);
        mybutton.SetActive(false);
        
        
        if (puntuacion >= 1) {
        CanvasFinal.text = ("Puntuació:     " + puntuacion);
        } else {
            CanvasFinal.text = "Puntuació:     0";
        }

            for (int i = 0; i < objetos.Length; i++) {
                objetos[i].SetActive(false);
                baile.GetComponent<Image>().sprite = normal;
            }
    }
}


