
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {

    private static HighscoreTable instance;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {

        instance = this;

        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        
        string jsonString = PlayerPrefs.GetString("highscoreTableEndlessRunner");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //highscores = null; // Reset Table   
        if (highscores == null) {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            PlayerPrefs.DeleteKey("highscoreTableEndlessRunner");
            AddHighscoreEntry(23, "VIU");
            AddHighscoreEntry(21, "ILF");
            AddHighscoreEntry(20, "LAM");
            AddHighscoreEntry(18, "AG2");
            AddHighscoreEntry(14, "NE0");
            AddHighscoreEntry(13, "OL2");
            AddHighscoreEntry(12, "VT0");
            AddHighscoreEntry(11, "AR!");
        }

        entryTemplate.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    private void Refresh() {

        string jsonString = PlayerPrefs.GetString("highscoreTableEndlessRunner");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Debug.Log(PlayerPrefs.GetString("highscoreTableEndlessRunner"));

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        if (highscoreEntryTransformList != null) {
            foreach (Transform highscoreEntryTransform in highscoreEntryTransformList) {
                Destroy(highscoreEntryTransform.gameObject);
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + ""; break;

        case 1: rankString = "1"; break;
        case 2: rankString = "2"; break;
        case 3: rankString = "3"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        // Cambiar el color de los ranking pares
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        
        // Highlight First
        if (rank == 1) {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        transformList.Add(entryTransform);
    }
    

    public static void AddHighscoreEntry_Static(int score, string name) {
        instance.AddHighscoreEntry(score, name);
    }

    private void AddHighscoreEntry(int score, string name) {
        // crear entrada ranking
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // cargar ranking
        string jsonString = PlayerPrefs.GetString("highscoreTableEndlessRunner");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        

        if (highscores == null) {
            // si no hay ranking hacer uno
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

       
        // Ordenar el array de mayor a menor en score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        // Añadir nuevo nombre
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Quitar el top 10
        if (highscores.highscoreEntryList.Count > 10) {
            highscores.highscoreEntryList.RemoveAt(9);
        }
       
       // Guardar datos
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTableEndlessRunner", json);
        PlayerPrefs.Save();
   
    }

    public static void Show() {
        instance.Refresh();
        instance.gameObject.SetActive(true);
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }

}
