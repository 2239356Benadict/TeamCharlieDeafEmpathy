using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(BoxCollider))]
public class ReceptionistandDoctorAnimationController : MonoBehaviour
{
    public Animator anim;
    public BoxCollider npcCollider;
    public DoctorWalkingAround doctorWalkingAroundScript;

    public AudioSource callingAudio;
    public bool canUserGo;

    public LockPlayerPosition playerPosition;

    public GameObject player;
    public DynamicMoveProvider playerDynamicMoveProvider;
    public TeleportationProvider playerTeleportMoveProvider;

    public int numberOfTimesDocCame;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        npcCollider = GetComponent<BoxCollider>();
        npcCollider.isTrigger = true;
        
        playerDynamicMoveProvider = GameObject.FindGameObjectWithTag("Player").GetComponent<DynamicMoveProvider>();
        playerTeleportMoveProvider = GameObject.FindGameObjectWithTag("Player").GetComponent<TeleportationProvider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Doctor") && doctorWalkingAroundScript.numberOfNPCDone == 4)
        {
            //WaveToThePatient();
        }
        //else if (other.CompareTag("Doctor") && doctorWalkingAroundScript.numberOfNPCDone == 3)
        //{
        //    //playerPosition.isLocked = false;
        //}
        else if (other.CompareTag("Player"))
        {
            callingAudio.Play();
        }
        else if (other.CompareTag("Player"))
        {
            anim.Play("Talking");
        }
        else if (other.CompareTag("Doctor"))
        {
            // To enable the player movement
            numberOfTimesDocCame++;

            
        }
    }

    private void Update()
    {
        UnFreezePlayer();
    }

    private void UnFreezePlayer()
    {
        if (numberOfTimesDocCame == 4)
        {
            //playerDynamicMoveProvider.enabled = true;
            Debug.Log("DynamicMove Enabled");
        }
    }
}
