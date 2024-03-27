using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Booter : BaseItem
{
    public int speed;

    public override void OnGetItem(GameObject Player)
    {
        base.OnGetItem(Player);
        Player.GetComponent<PlayerCar>().rb.velocity += Player.transform.forward * speed;
    }
}
