using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ReceptionistandDoctorAnimationController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider npcCollider;
    public DoctorWalkingAround doctorWalkingAroundScript;

    public AudioSource callingAudio;
    public bool canUserGo;

    public LockPlayerPosition playerPosition;


    void Start()
    {
        anim = GetComponent<Animator>();
        npcCollider = GetComponent<BoxCollider>();
        npcCollider.isTrigger = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor") && doctorWalkingAroundScript.numberOfNPCDone == 4)
        {
            WaveToThePatient();
        }
        else if (other.CompareTag("Doctor") && doctorWalkingAroundScript.numberOfNPCDone == 3)
        {
            playerPosition.isLocked = false;
        }
        else if (other.CompareTag("Player"))
        {
            callingAudio.Play();
        }
        else if (other.CompareTag("Player"))
        {
            anim.Play("Talking");
        }
    }


    public void WaveToThePatient()
    {
        StartCoroutine(WavingThePatient());
    }
    IEnumerator WavingThePatient()
    {
        yield return new WaitForSeconds(5f);
        canUserGo = true;
        yield return new WaitForSeconds(0.5f);
        canUserGo = false;
        yield return new WaitForSeconds(2f);
        canUserGo = true;
    }

    void WaveToPatient()
    {
        if (canUserGo)
        {
            anim.Play("Waving");
        }
        else
        {
            anim.Play("Sit Idle");
        }
    }
}
