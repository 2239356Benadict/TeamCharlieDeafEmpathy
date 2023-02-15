using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckXRRigStatus : MonoBehaviour
{
    public HandAndMovement handStatus;
    public bool teleportMovementStatus = false;

    private void Start()
    {
        teleportMovementStatus = false;
        handStatus = GameObject.FindObjectOfType<HandAndMovement>();
    }
    public void IsTeleportMovementSelected()
    {
        if (handStatus.teleportMovement)
        {
            teleportMovementStatus = true;
        }
    }
}
