using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class HandAndMovement : MonoBehaviour
{
    public bool leftHandUser;
    public bool righttHandUser;

    public bool continuousMotion;
    public bool teleportMovement;

    //public ActionBasedController basedController;
    public ActionBasedControllerManager leftHandControllerManager;
    public ActionBasedControllerManager rightHandControllerManager;

    [SerializeField]
    private GameObject leftXRRayInteractorGO;
    private XRRayInteractor leftXRRayInteractor;
    [SerializeField]
    private GameObject rightXRRayInteractorGO;
    private XRRayInteractor rightXRRayInteractor;


    private void Start()
    {
        //basedController = GameObject.FindObjectOfType<ActionBasedController>();
        leftXRRayInteractorGO = GameObject.FindGameObjectWithTag("LeftHandTeleportInteractor");
        rightXRRayInteractorGO = GameObject.FindGameObjectWithTag("RightHandTeleportInteractor");
    }

    
    // Method to set Left hand as dominant hand
    public void Lefthander()
    {
        leftHandUser = true;
        righttHandUser = false;
    }

    // Method to set Right hand as dominant hand
    public void Righthander()
    {
        righttHandUser = true;
        leftHandUser = false;
    }

    //Method to enable only continuous movement
    public void HandContinuusMovementType()
    {
        continuousMotion = true;
        teleportMovement = false;
        if (leftHandUser)
        {
            leftHandControllerManager.smoothMotionEnabled = true;
            rightHandControllerManager.smoothMotionEnabled = false;
            leftHandControllerManager.CancelTeleportationMovement();
        }
        else if (righttHandUser)
        {
            rightHandControllerManager.smoothMotionEnabled = true;
            leftHandControllerManager.smoothMotionEnabled = false;
            rightHandControllerManager.CancelTeleportationMovement();
        }
    }

    // Method to enable only teleport movement
    public void HandTeleportationMovementType()
    {
        continuousMotion = false;
        teleportMovement = true;
        if (leftHandUser)
        {
            leftHandControllerManager.smoothMotionEnabled = false;
            rightXRRayInteractor.enabled = false;
        }
        else if (righttHandUser)
        {
            rightHandControllerManager.smoothMotionEnabled = false;
            leftXRRayInteractor.enabled = false;
        }
    }

}
