using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRigStatus : MonoBehaviour
{
    [SerializeField]
    private bool teleportationOpted;
    [SerializeField]
    private TeleportationArea hospitalTeleportArea;
    [SerializeField]
    public CheckXRRigStatus xRRigStatus;


    private void Awake()
    {
        hospitalTeleportArea = GameObject.FindObjectOfType<TeleportationArea>();
        xRRigStatus = GameObject.FindObjectOfType<CheckXRRigStatus>();
    }

    private void Start()
    {
        ActivateOrDeactiveteTeleportArea();
    }


    public void ActivateOrDeactiveteTeleportArea()
    {
        if (xRRigStatus.teleportMovementStatus)
        {
            hospitalTeleportArea.enabled = true;
        }
        else if (!xRRigStatus.teleportMovementStatus)
        {
            hospitalTeleportArea.enabled = false;
        }
    }
}
