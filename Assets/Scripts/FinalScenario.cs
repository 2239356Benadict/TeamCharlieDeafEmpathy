using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScenario : MonoBehaviour
{
    public GameObject endPanel;
    [SerializeField]
    private AudioSource audioSource;
    public int timeToUIShowUp;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        endPanel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableTheUI();
        }
    }

    public void EnableTheUI()
    {
        endPanel.SetActive(true);
    }
}
