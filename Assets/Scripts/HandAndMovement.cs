using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class HandAndMovement : MonoBehaviour
{
    public ActionBasedController basedController;
    public ActionBasedControllerManager controllerManager;

    private void Start()
    {
        basedController = GameObject.FindObjectOfType<ActionBasedController>();
        controllerManager = GameObject.FindObjectOfType<ActionBasedControllerManager>();     
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
