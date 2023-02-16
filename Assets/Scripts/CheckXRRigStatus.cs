using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckXRRigStatus : MonoBehaviour
{
    public HandAndMovement handStatus;
    public bool teleportMovementStatus = false;

    public bool isLeftDominantHand;
    public bool isRightDominantHand;

    private void Start()
    {
        teleportMovementStatus = false;
        isLeftDominantHand = false;
        isRightDominantHand = false;
        handStatus = GameObject.FindObjectOfType<HandAndMovement>();
    }
    public void IsTeleportMovementSelected()
    {
        if (handStatus.teleportMovement)
        {
            teleportMovementStatus = true;
        }
        else
        {
            teleportMovementStatus = false;
        }
        isLeftDominantHand = handStatus.leftHandUser;
        isRightDominantHand = handStatus.righttHandUser;
    }
}
