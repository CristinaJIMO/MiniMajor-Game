using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // para poder resetear la escena

public class SceneController : MonoBehaviour
{
    private MainCard primera_carta;
    private MainCard segunda_carta;

    public const int filas = 2;
    public const int columnas = 8;
    public const float disX = 2f;
    public const float disY = 4f;
    
    
    public GameObject CanvasObject;
    public Text puntos;
    public AudioSource SFX_win;
    public UI SumarTiempo;
    public int _score = 0;

    public GameObject mybutton2;
    public Button BotonPause;
    public Button BotonPlay; 
    public Button VolverMenu;
    public Button VolverFinalDerrota;
    public Button VolverFinalVictoria;
    
    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;


    private void Start()
    {
        Time.timeScale = 1;

        Button btnpause = BotonPause.GetComponent<Button>();
        btnpause.onClick.AddListener(ParaTiempo); 

        Button btnplay = BotonPlay.GetComponent<Button>();
        btnplay.onClick.AddListener(SigueTiempo);  

        Button btnmenu = VolverMenu.GetComponent<Button>();
        btnmenu.onClick.AddListener(SigueTiempo);  
        
        Button btnfinalderrota = VolverFinalDerrota.GetComponent<Button>();
        btnfinalderrota.onClick.AddListener(SigueTiempo);

        Button btnfinalvictoria = VolverFinalVictoria.GetComponent<Button>();
        btnfinalvictoria.onClick.AddListener(SigueTiempo);  
         
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
        numbers = ShuffleArray(numbers);

        for(int i = 0; i < columnas; i++)       // Colocar las cartas tapadas
        {
            for (int j = 0; j < filas; j++)
            {
                MainCard card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;              
                }
                
                int index = j * columnas + i;
                int id = numbers [index];
                card.ChangeSprite(id, images[id]);

                float posX = (disX * i) + startPos.x;
                float posY = (disY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z); 
            }
        }
    }

    private int[] ShuffleArray(int[]numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++){

            int tmp = newArray[i];
            int r = Random.Range(i,newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public bool canReveal
    {
        get { return segunda_carta == null; }   // "inicio" si la segunda carta esta en null
    }

    public void CardRevealed(MainCard card)
    {
        if(primera_carta == null)
        {
            primera_carta = card;
        }
        else
        {
            segunda_carta = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {

        if (primera_carta.id == segunda_carta.id) // si las dos coinciden
        {
            _score++;    // Suma 1 punto por pareja
            puntos.text = "" + _score;

            SumarTiempo.tiempo = SumarTiempo.tiempo +5f;  // Suma 5 segundos 
        }
        else    // Si las cartas no coinciden
        {
            yield return new WaitForSeconds(0.5f); //esperar 0.5s y taparlas
            primera_carta.Unreveal();
            segunda_carta.Unreveal();
        }
        primera_carta = null;
        segunda_carta = null;

        // Si consigues las 8 parejas activa el panel de win
        if (_score == 8) { 

            CanvasObject.SetActive(true);
            mybutton2.SetActive(false);
            SFX_win.Play();
        }  
    }

    public void Restart() {     // boton restart
        
        SceneManager.LoadScene("SampleScene");
    }

    void ParaTiempo(){
        Time.timeScale = 0;
    }

    void SigueTiempo(){
        Time.timeScale = 1;
    }
}

