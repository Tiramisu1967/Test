using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRacingCar : BaseCar
{

    public override void Movement()
    {
        motor = Maxmoter;
        if (TargetPoint == null) TargetPoint = WayPoint.GetChild(WayIndex);
        if(Vector3.Distance(TargetPoint.position, transform.position) <= 10)
        {
              WayIndex += 1;
              TargetPoint = WayPoint.GetChild(WayIndex);

              if(WayIndex == WayPoint.childCount - 1)
              {
                WayIndex = 0;
                Destroy(this);
              }
        }
        Vector3 waypointRelativeDistance = transform.InverseTransformPoint(TargetPoint.position);
        waypointRelativeDistance /= waypointRelativeDistance.magnitude;
        steering = (waypointRelativeDistance.x / waypointRelativeDistance.magnitude) * 25;
        base.Movement();
    }
}
