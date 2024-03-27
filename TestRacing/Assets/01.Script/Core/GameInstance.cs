using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Parts
{

    //해당 레벨 값에 코인을 사용해서 구매, 비교는 해당 값이 더 큰가
    public int[] PartCoin;
    public int PartLavel; 
}



public class GameInstance : MonoBehaviour
{
    public static GameInstance instance;

    #region Player
    public List<Parts> Part;
    public int[] MaxLabs;
    public int Coin;
    public float RacingTime;
    #endregion

    #region Stage
    public int Stage = 1;
    public int[] StageTiem;
    #endregion


    public void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } 
        else
        {
            Destroy(this);
        }
    }
}
