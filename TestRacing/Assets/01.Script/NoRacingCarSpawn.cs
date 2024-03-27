using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRacingCarSpawn : MonoBehaviour
{
    public GameObject NoRacingCar;
    public Transform SpawnPoint;
    public Transform WayPoints;
    void Update()
    {
         
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);
        GameObject Car = Instantiate(NoRacingCar, SpawnPoint.position, Quaternion.identity);
        Car.GetComponent<NoRacingCar>().WayPoint = WayPoints;
    }
}
