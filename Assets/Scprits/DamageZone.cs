using System;
using System.Collections;
using System.Collections.Generic;
using Scprits;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    ThrottleDispatcher _throttleDispatcher = new ThrottleDispatcher(4000); 
    DelayAction delay = new DelayAction();
 
   private void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller)
        {
            delay.Throttle(2000,null, () =>
            {
                controller.changeHealth(-1); 
            });
            
            
        }
    }
}
