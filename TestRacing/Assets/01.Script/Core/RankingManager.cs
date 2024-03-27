using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    public List<float> Ranking;
    public TextMeshProUGUI[] RankingText;
    public Canvas MainCanvas;
    public Canvas RankingCanvas;
    void Start()
    {
        if(GameInstance.instance != null)
        {
            RankingUpdate();
        }
            RankingSet();
    }


    public void GameStart()
    {
        if(GameInstance.instance != null)
        {
            GameInstance.instance.Coin = 0;
            GameInstance.instance.Stage = 1;
            GameInstance.instance.RacingTime = 0; 
            for(int i = 0; i < GameInstance.instance.Part.Count; i++)
            {
                GameInstance.instance.Part[i].PartLavel = 0;
            }
        }
        SceneManager.LoadScene("Stage1");
    }

    public void RankingBord()
    {
        RankingCanvas.gameObject.SetActive(true);
        MainCanvas.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        RankingCanvas.gameObject.SetActive(false);
        MainCanvas.gameObject.SetActive(true);
    }
    public void RankingUpdate()
    {
        if(GameInstance.instance.RacingTime <= Ranking[4])
        {
            Ranking[4] = GameInstance.instance.RacingTime;
            for(int i = 0; i < Ranking.Count; i++)
            {
                for(int j = i + 1; j < Ranking.Count; j++)
                {
                    if (Ranking[i] >= Ranking[j])
                    {
                        float current = Ranking[i];
                        Ranking[i] = Ranking[j];
                        Ranking[i] = current;
                    }
                }
            }
        }
    }

    public void RankingSet()
    {
        for(int i = 1; i < Ranking.Count; i++)
        {
            RankingText[i - 1].text = $"{i - 1} : {Ranking[i]}";
        }
    }
}
