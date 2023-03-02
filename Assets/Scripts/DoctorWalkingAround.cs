using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorWalkingAround : MonoBehaviour
{
    public Transform[] points;
    public Transform wayback;
    public GameObject followDoctorCheckpoint;
    
    private NavMeshAgent agent;

    public Animator doctorAnimator;
    public AnimationClip[] doctorAnimationClip;
    public AnimationClip doctorAnimationClipLength;
    //public Animation nPCAnimation;

    private int destPoint = 0;
    public int numberOfNPCDone;
    public int timerValue;
    public int doctorWaitingTime;
    public float doctorWalkingRepeatTime;
    public float receptionWaitingTime;

    public bool isGoneBack;
    public bool isAtReceptionArea;
    public bool canNPCFollow;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        isAtReceptionArea = false;
        canNPCFollow = false;
        followDoctorCheckpoint.SetActive(false);
        // invoke the doctors to and fro movement
        InvokeRepeating("WalkAround", 1, doctorWalkingRepeatTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ReceptionAreaForDoc")
        {
            isAtReceptionArea = true;
            isGoneBack = false;
            numberOfNPCDone++;
            doctorAnimator.Play("Talking");

            followDoctorCheckpoint.SetActive(true);
        }
        else if (other.tag == "DoctorDesk")
        {
            isAtReceptionArea = false;
            isGoneBack = true;
            canNPCFollow = false;
            followDoctorCheckpoint.SetActive(false);
        }
        else if (other.tag == "FollowDoctor")   //"NPCStarter"
        {
            canNPCFollow = true;
            
            Debug.Log("FollowDoc");
        }
        else if (other.tag == "ReceptionAreaForDoc" && numberOfNPCDone == 4)
        {
            isAtReceptionArea = true;
            isGoneBack = true;
            numberOfNPCDone++;
            if (timerValue < doctorWaitingTime)
            {
                doctorAnimator.Play("Idle");
            }
            else
            {
                WalkAround();
            }

            followDoctorCheckpoint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;
        
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1);// % points.Length;        
    }

    public void WalkAround()
    {
        StartCoroutine(WalkBetweenPoints());
    }

    public IEnumerator WalkBetweenPoints()
    {
        agent.destination = points[5].position;
        yield return new WaitForSeconds(5);
        if (isAtReceptionArea)
        {
            yield return new WaitForSeconds(receptionWaitingTime);
            doctorAnimator.Play("Walking");
            agent.destination = wayback.position;
            isAtReceptionArea = false;
            isGoneBack = true;
        }
        yield return new WaitForSeconds(1);

        Debug.Log("Doctor is walking between two points");
    }

}
