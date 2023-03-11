///Copywrite @ '2239356@swansea university'
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts helps to freeze the movement of the gameobject attached with this script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class LockPlayerPosition : MonoBehaviour
{

    public GameObject gameObjectToLock;
    [SerializeField]
    private Rigidbody lockingObjectRigidBody;
    [SerializeField]
    private DynamicMoveProvider xROriginDynamicMoveProvider;
    [SerializeField]
    private int numberOfTimes;
    private int nPCToGo;

    public bool isLocked;

    public DoctorWalkingAround docWalkAround;

    private void Start()
    {
        gameObjectToLock = GameObject.FindGameObjectWithTag("Player");
        lockingObjectRigidBody = gameObjectToLock.GetComponent<Rigidbody>();
        xROriginDynamicMoveProvider = gameObjectToLock.GetComponent<DynamicMoveProvider>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numberOfTimes++;
            
        }

        if (numberOfTimes == 2 && other.CompareTag("Player") && nPCToGo < 4)
        {
            //xROriginDynamicMoveProvider.enabled = false;

            //StartCoroutine(LockPosition());
            //LockPos();  
        }
    }

    public void LockPos()
    {
        //lockingObjectRigidBody.constraints = RigidbodyConstraints.FreezePosition;
    }

    private IEnumerator LockPosition()
    {
        xROriginDynamicMoveProvider.enabled = false;
        yield return new WaitForSeconds(500f);
        xROriginDynamicMoveProvider.enabled = true;
    }

    private void Update()
    {
        //if (isLocked)
        //{
        //    xROriginDynamicMoveProvider.enabled = false;
        //}
        //else
        //{
        //    xROriginDynamicMoveProvider.enabled = true;
        //}
    }
}
