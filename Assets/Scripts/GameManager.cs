using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject doctorNPC;
    public GameObject doctorPassCheckpoint;

    public FollowThePath receptionistToStandUp;
    
    public GameObject[] patientsArray;

    [SerializeField]
    private DoctorWalkingAround doctor;

    public int nPCToMove;

    private void Start()
    {
        doctor = doctorNPC.GetComponent<DoctorWalkingAround>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DoctorTargetArea")
        {
            //nPCToMove++;
            NPCWalkingController();
        }
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
        if (doctor.isWaitingForUser)
        {
            receptionistToStandUp.nPCAnimator.Play("Sit To Stand");
        }
    }

}
