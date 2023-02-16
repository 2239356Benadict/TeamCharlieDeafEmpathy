using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;


public class TeleportationStatus : MonoBehaviour
{
    public CheckXRRigStatus rigStatus;

    private void Awake()
    {
        
    }
    private void Start()
    {
        if (rigStatus.teleportMovementStatus)
        {
            LeftXRTeleportRayEnableOrDisable();
            RightXRTeleportRayEnableOrDisable();
        }
        else if (!rigStatus.teleportMovementStatus)
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
        }
        Debug.Log("XR RayInteractor Choice");
    }

    public void LeftXRTeleportRayEnableOrDisable()
    {
        if (rigStatus.isLeftDominantHand && gameObject.tag == "LeftTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = true;
            Debug.Log("Left XR RayInteractor enabled");
        }
        else if (!rigStatus.isLeftDominantHand && rigStatus.isRightDominantHand && gameObject.tag == "LeftTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
            Debug.Log("Left XR RayInteractor disabled");
        }
    }

    public void RightXRTeleportRayEnableOrDisable()
    {
        if (rigStatus.isRightDominantHand && gameObject.tag == "RightTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = true;
            Debug.Log("Right XR RayInteractor enabled");
        }
        else if (!rigStatus.isRightDominantHand && rigStatus.isLeftDominantHand && gameObject.tag == "RightTeleportInteractor")
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
            Debug.Log("Right XR RayInteractor disabled");
        }
    }


    private void Update()
    {
        if (rigStatus.teleportMovementStatus)
        {
            LeftXRTeleportRayEnableOrDisable();
            RightXRTeleportRayEnableOrDisable();
        }
        else if (!rigStatus.teleportMovementStatus)
        {
            gameObject.GetComponent<XRRayInteractor>().enabled = false;
        }
        Debug.Log("XR RayInteractor Choice");
    }
}
