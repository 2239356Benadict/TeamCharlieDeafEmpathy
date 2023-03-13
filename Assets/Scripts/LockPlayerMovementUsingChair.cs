using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LockPlayerMovementUsingChair : MonoBehaviour
{
    [SerializeField]
    private TeleportationArea hospitalTeleportArea;

    [SerializeField]
    private FreezeTheUser userMovementFreezeScript;

    [SerializeField]
    public int numberOfTimesPlayerCollided;

    private void Awake()
    {
        userMovementFreezeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FreezeTheUser>();
    }
    private void Start()
    {
        hospitalTeleportArea = GameObject.FindGameObjectWithTag("TeleportArea").GetComponent<TeleportationArea>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(userMovementFreezeScript.timesColliedeWithChair == 2)
        {
            hospitalTeleportArea.enabled = false;
            userMovementFreezeScript.moveProvider.enabled = false;
        }
    }
}
