using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_button : MonoBehaviour
{
    public GameObject pre_score;

    public void OnMouseUp()
    {
        int finalScore = LevelGenerator.GetlevelPartCount() + Coin.chupetes - 5;
        HighscoreNameInputWindow.Show(finalScore, (string name) => {
        HighscoreTable.AddHighscoreEntry_Static(finalScore, name);
        HighscoreTable.Show();     
        });
        pre_score.SetActive(false);
    }


}
