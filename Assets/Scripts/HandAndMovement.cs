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

    private void Start()
    {
        //basedController = GameObject.FindObjectOfType<ActionBasedController>();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Lefthander()
    {
        leftHandUser = true;
        righttHandUser = false;
    }

    public void Righthander()
    {
        righttHandUser = true;
        leftHandUser = false;
    }

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
    public void HandTeleportationMovementType()
    {
        continuousMotion = false;
        teleportMovement = true;
        if (leftHandUser)
        {
            leftHandControllerManager.smoothMotionEnabled = false;
            
        }
        else if (righttHandUser)
        {
            rightHandControllerManager.smoothMotionEnabled = false;
        }
    }

    public void HandMovementType()
    {
        if (leftHandUser)
        {
        }
    }
}
