using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]

public class ReceptionistandDoctorAnimationController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider npcCollider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        npcCollider = GetComponent<BoxCollider>();
        npcCollider.isTrigger = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor"))
        {

            anim.Play("Sit To Stand");
        }
    }
}
