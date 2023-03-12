using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FreezeTheUser : MonoBehaviour
{
    [SerializeField]
    private DynamicMoveProvider moveProvider;

    private void Start()
    {
        moveProvider = gameObject.GetComponent<DynamicMoveProvider>();
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
        Debug.Log("Player reached final destination");
        
    }
}
