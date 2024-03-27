using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public virtual void OnGetItem(GameObject Player) { 
    }
}

public class ItemSpawnManager : MonoBehaviour
{
    public GameObject[] Item;
    public Transform SpawnPoints;
    public int Index;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        
        for(int i = 0; i < SpawnPoints.childCount; i++)
        {
            int current = Random.Range(0, Item.Length);
            Instantiate(Item[current], SpawnPoints.GetChild(Index).position, Quaternion.identity);
            Index++;
        }
        Index = 0;
        
    }
}
