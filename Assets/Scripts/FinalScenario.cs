using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScenario : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject npcToStandBehind;

    [SerializeField]
    private AudioSource audioSource;
    public int timeToUIShowUp;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        endPanel.SetActive(false);
        npcToStandBehind.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableTheUI();
            StartCoroutine(EnableNPC());
        }
    }

    public void EnableTheUI()
    {
        endPanel.SetActive(true);
    }

    public IEnumerator EnableNPC()
    {
        yield return new WaitForSeconds(3f);
        npcToStandBehind.SetActive(true);
    }
}
