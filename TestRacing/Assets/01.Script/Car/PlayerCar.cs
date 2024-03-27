using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCar :BaseCar
{
    [HideInInspector] public float Speed;
    public  void init(GameManager _gameManager)
    {
        gameManager = _gameManager; 
    }
    public override void Movement()
    {
        motor = Maxmoter * Input.GetAxis("Vertical");
        steering = Maxsteering * Input.GetAxis("Horizontal");
        Break = Input.GetKey(KeyCode.Space) ? BreakForce : 0;

        base.Movement();
    }

    public override void LocalPosition(WheelCollider collider)
    {
        if(collider.transform.childCount == 0)
        {
            return;
        }
        if (TargetPoint == null) TargetPoint = WayPoint.GetChild(WayIndex);
        if(Vector3.Distance(TargetPoint.position, transform.position) <= 25 && WayPoint.childCount > WayIndex + 1)
        {
            WayIndex += 1;
            TargetPoint = WayPoint.GetChild(WayIndex);

            if(WayIndex == WayPoint.childCount - 1)
            {
                WayIndex = 0;
                Lab++;
                TargetPoint = WayPoint.GetChild(WayIndex);
            }
        } 
        Speed = rb.velocity.magnitude * 3.6f;
        base.LocalPosition(collider);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<BaseItem>())
        {
            collision.GetComponent<BaseItem>().OnGetItem(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
