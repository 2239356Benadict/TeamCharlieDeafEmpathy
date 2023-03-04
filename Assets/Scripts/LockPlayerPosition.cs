using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerPosition : MonoBehaviour
{
    public int numberOfTimes;

    public GameObject gameObjectToLock;
    [SerializeField]
    private Rigidbody lockingObjectRigidBody;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObjectToLock = other.gameObject;
        lockingObjectRigidBody = gameObjectToLock.GetComponent<Rigidbody>();
        numberOfTimes++;
        if (numberOfTimes == 2)
        {
            StartCoroutine(LockPosition());
        }
    }

    IEnumerator LockPosition()
    {
        gameObjectToLock.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(3);
        gameObjectToLock.transform.position = gameObjectToLock.transform.position;

    }
}
