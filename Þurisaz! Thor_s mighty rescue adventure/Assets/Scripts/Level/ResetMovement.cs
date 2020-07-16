using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        WallTrigger.WallW = 1;
        WallTrigger.WallA = 1;
        WallTrigger.WallS = 1;
        WallTrigger.WallD = 1;
        PlayerManager.ObstacleW = 1;
        PlayerManager.ObstacleA = 1;
        PlayerManager.ObstacleS = 1;
        PlayerManager.ObstacleD = 1;
    }
}
