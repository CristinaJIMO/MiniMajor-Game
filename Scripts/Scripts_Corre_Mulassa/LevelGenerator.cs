using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{

   // public AudioSource SFX_point;

    private static LevelGenerator instance;
    private const float Player_Distance_Spawn = 100f;
    
    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelPartEasyList;
    [SerializeField] private List<Transform> levelPartNormalList;
    [SerializeField] private List<Transform> levelPartHardList;
    [SerializeField] private List<Transform> levelPartChallengingList;
    [SerializeField] private Player_2 player;
   
    private Vector3 lastPositionMark;
    private int levelPartCount;

    private enum Contador {Easy, Normal, Hard, Challenging}

    public Button BotonPause;
    public Button BotonPlay;
    public Button VolverMenu;
    public Button VolverFinal;

    private void Awake() {

        instance = this;
        lastPositionMark = (levelStart.Find("PositionMark").position);
        int startingSpawns = 5;
        for (int i = 0; i < startingSpawns; i++){
            SpawnLevelPart();
        }
    }

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

    private void Update() {

        if (Vector3.Distance(player.GetComponent<Transform>().position, lastPositionMark) < Player_Distance_Spawn) {
            
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart() {
        
        List <Transform> ContadorLevelPartList;

        switch (getCount()) {

        default: 
        case Contador.Easy:         ContadorLevelPartList = levelPartEasyList;          break;
        case Contador.Normal:       ContadorLevelPartList = levelPartNormalList;        break;
        case Contador.Hard:         ContadorLevelPartList = levelPartHardList;          break;
        case Contador.Challenging:  ContadorLevelPartList = levelPartChallengingList;   break;
        }

        Transform RandomLevelPart = ContadorLevelPartList[Random.Range(0, ContadorLevelPartList.Count)];
       
        Transform lastLevelPartTransform = SpawnLevelPart(RandomLevelPart, lastPositionMark);
        lastPositionMark = lastLevelPartTransform.Find("PositionMark").position;
        levelPartCount++;
        //SFX_point.Play();
    }
    
    
    private Transform SpawnLevelPart (Transform levelPart, Vector3 spawnPosition) {

        Transform levelPartTransform = Instantiate (levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform; 
        
    }

    private Contador getCount() {

        if (levelPartCount >= 26) return Contador.Challenging;
        if (levelPartCount >= 18) return Contador.Hard;
        if (levelPartCount >= 10) return Contador.Normal;
        return Contador.Easy;


    }

    public static int GetlevelPartCount() {
      
        return instance.levelPartCount;
    }

    public void Restart() {
        
        SceneManager.LoadScene("Mulassa_Runner");
    }

    void ParaTiempo(){
        Time.timeScale = 0;
    }

    void SigueTiempo(){
        Time.timeScale = 1;
    }
}
