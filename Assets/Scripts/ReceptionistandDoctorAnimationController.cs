using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ReceptionistandDoctorAnimationController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider npcCollider;
    public DoctorWalkingAround doctorWalkingAroundScript;


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
            StartCoroutine(WavingThePatient());
        }
        else if (other.CompareTag("Player"))
        {
            anim.Play("Talking");
        }
    }

    IEnumerator WavingThePatient()
    {
        yield return new WaitForSeconds(5f);
        anim.Play("Sit To Stand");
        yield return new WaitForSeconds(2f);
        anim.Play("Waving");
    }
}
