using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BaseItem
{
    public int GetCoinAmount;

    public override void OnGetItem(GameObject Player)
    {
        base.OnGetItem(Player);
        GameInstance.instance.Coin += GetCoinAmount;
    }
}
