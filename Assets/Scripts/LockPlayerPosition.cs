///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts helps to freeze the movement of the gameobject attached with this script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{

    public GameObject gameObjectToLock;
    [SerializeField]
    private Rigidbody lockingObjectRigidBody;
    [SerializeField]
    private int numberOfTimes;

    private void Start()
    {
        gameObjectToLock = GameObject.FindGameObjectWithTag("Player");
        lockingObjectRigidBody = gameObjectToLock.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numberOfTimes++;
        }

        if (numberOfTimes == 2 && other.CompareTag("Player"))
        {
            //StartCoroutine(LockPosition());
            LockPos();
        }
    }

    public void LockPos()
    {
        lockingObjectRigidBody.constraints = RigidbodyConstraints.FreezePosition;
    }

    private IEnumerator LockPosition()
    {
        lockingObjectRigidBody.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(3);
        lockingObjectRigidBody.constraints = RigidbodyConstraints.None;

    }
}
