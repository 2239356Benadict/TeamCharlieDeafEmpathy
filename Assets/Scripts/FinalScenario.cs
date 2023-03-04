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
            StartCoroutine(EnableTheUI());
        }
    }

    IEnumerator EnableTheUI()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        endPanel.SetActive(true);
    }
}
