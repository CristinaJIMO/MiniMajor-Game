using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{   
    public Button BotonPause;
    public Button BotonPlay;
    public Button VolverMenu;
    public Button VolverFinal;
    

    void Start() {

        Time.timeScale = 1;

        Button btnpause = BotonPause.GetComponent<Button>();
        btnpause.onClick.AddListener(ParaTiempo); 

        Button btnplay = BotonPlay.GetComponent<Button>();
        btnplay.onClick.AddListener(SigueTiempo);

        Button btnmenu = VolverMenu.GetComponent<Button>();
        btnmenu.onClick.AddListener(SigueTiempo);  
        
        Button btnfinal = VolverFinal.GetComponent<Button>();
        btnfinal.onClick.AddListener(SigueTiempo);  

    }

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
    }

    public void Restart() {
       
        SceneManager.LoadScene("Drac");
    }

    void ParaTiempo(){
        Time.timeScale = 0;
        
    }

    void SigueTiempo(){
        Time.timeScale = 1;
        
    }
}
