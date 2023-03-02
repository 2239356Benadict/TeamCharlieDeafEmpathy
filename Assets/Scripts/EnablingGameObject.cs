using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingGameObject : MonoBehaviour
{
    public BoxCollider colliderOfGO;
    public GameObject infoPanel;
    [SerializeField]
    private int numberOfTimesCollided;

    private void Start()
    {
        colliderOfGO = gameObject.GetComponent<BoxCollider>();
        infoPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            numberOfTimesCollided++;
            if(numberOfTimesCollided == 2)
            {
                infoPanel.SetActive(true);
            }
        }
    }

    IEnumerator EnableThePanel()
    {
        return null; 
    }
}
