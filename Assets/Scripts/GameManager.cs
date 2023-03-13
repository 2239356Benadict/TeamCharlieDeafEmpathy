///Copywrite @ 2239356@swansea university
///Date:05/03/2023
///Author: Benadict Joseph
///This scripts helps the user in managing the NPCs.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public GameObject doctorNPC;
    public GameObject doctorPassCheckpoint;

    public GameObject receptionistToStandUp;
    public GameObject initialPlayerRestrictedArea;
    public TeleportationArea playerInitialTeleportRestrictedArea;
    public Animator receptionistStandUp;
    
    public GameObject[] patientsArray;

    [SerializeField]
    private DoctorWalkingAround doctor;
    public ReceptionistandDoctorAnimationController receptionistandDocAnimatorController;

    public FollowThePath npcToFollowPlayer;

    public int nPCToMove;

    private void Start()
    {
        doctor = doctorNPC.GetComponent<DoctorWalkingAround>();
        receptionistStandUp = receptionistToStandUp.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Doctor")  //DoctorTargetArea
        {
            //nPCToMove++;
            NPCWalkingController();
        }
        //else if(other.tag == "Player")
        //{
        //    // NPC follow the player and stand behind the player
        //    //npcToFollowPlayer.startFollowing = true;
        //}
    }
    public void NPCWalkingController()
    {
        if (doctor.canNPCFollow && nPCToMove <= patientsArray.Length)
        {
            //nPCToMove = doctor.numberOfNPCDone;
            nPCToMove++;
            patientsArray[nPCToMove - 1].GetComponent<FollowThePath>().startFollowing = true;
            Debug.Log("For Loop" + patientsArray[nPCToMove - 1].GetComponent<FollowThePath>().startFollowing);
            doctor.canNPCFollow = false;
            doctorPassCheckpoint.GetComponent<BoxCollider>().isTrigger = true;
        }

        if (doctor.isGoneBack)
        {
            doctorPassCheckpoint.GetComponent<BoxCollider>().isTrigger = false;
        }
    }


    private void Update()
    {
        ReceptionistWaveToLobby();
    }

    public bool wave;
    public void ReceptionistWaveToLobby()
    {
        if (doctor.isWaitingForUser)
        {
            receptionistStandUp.Play("Waving");
            receptionistandDocAnimatorController.playerDynamicMoveProvider.enabled = true; // enabling movement of player
            receptionistandDocAnimatorController.playerTeleportMoveProvider.enabled = true;
            initialPlayerRestrictedArea.SetActive(false);
            playerInitialTeleportRestrictedArea.enabled = true;
        }
    }
}
