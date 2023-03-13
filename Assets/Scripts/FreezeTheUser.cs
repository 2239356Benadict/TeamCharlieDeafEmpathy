using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;

public class FreezeTheUser : MonoBehaviour
{
    public DynamicMoveProvider moveProvider;
    public TeleportationProvider teleportProviderfinal;

    public int timesColliedeWithChair;

    private void Start()
    {
        moveProvider = gameObject.GetComponent<DynamicMoveProvider>();
        teleportProviderfinal = gameObject.GetComponent<TeleportationProvider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VacantChair"))
        {
            timesColliedeWithChair++;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "FinalDestination")
        {
            StartCoroutine(ReachedFinalDestination());
            //moveProvider.enabled = false;
            //Debug.Log("Player reached final destination");
        }
    }

    private IEnumerator ReachedFinalDestination()
    {
        yield return new WaitForSeconds(2f);
        
        moveProvider.enabled = false;
        teleportProviderfinal.enabled = false;
        Debug.Log("Player reached final destination");
        
    }

    private void FinalDestinationReached()
    {
        moveProvider.enabled = false;
    }
}
