using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemhealth: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController)
        {
            playerController.changeHealth(1);
            Destroy(gameObject);
        }
    }
}
