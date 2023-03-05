using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]

public class DoctorandPatientAnimatorScript : MonoBehaviour
{
    public Animator anim;
    public BoxCollider DoctorsRoomCollider;

    void Start()
    {
        anim = GetComponent<Animator>();
        //DoctorsRoomCollider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        //DoctorsRoomCollider.isTrigger = true;
        DoctorsRoomCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("Typing");
        }
    }
}

