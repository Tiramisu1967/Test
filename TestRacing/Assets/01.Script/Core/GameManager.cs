using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerCar player;
    public AICar AI;
    public PlayerUIManager UiManager;

    void Start()
    {
        player.init(this);
        AI.init(this);
        UiManager.init(this);
    }
    
    public void Update()
    {
        GameInstance.instance.RacingTime += Time.deltaTime;
        WinOrLose();
    }

    public void WinOrLose()
    {
        if (AI.Lab == GameInstance.instance.MaxLabs[GameInstance.instance.Stage -1])
        {
            SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");
        }
        else if (player.Lab == GameInstance.instance.MaxLabs[GameInstance.instance.Stage -1])
        {
            if (GameInstance.instance.Stage == 3)
            {
                SceneManager.LoadScene("Main");

            } 
            else
            {
                GameInstance.instance.Stage += 1;
                SceneManager.LoadScene($"Stage{GameInstance.instance.Stage}");

            }
        }
    }
}
