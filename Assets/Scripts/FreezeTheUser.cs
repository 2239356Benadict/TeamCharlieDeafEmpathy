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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinalDestination")
        {
            moveProvider.enabled = false;
            Debug.Log("Player reached final destination");
        }
    }


}
