using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorWalkingAround : MonoBehaviour
{
    public Transform[] points;
    public Transform wayback;

    private NavMeshAgent agent;

    public Animator doctorAnimator;
    public AnimationClip[] doctorAnimationClip;

    private int destPoint = 0;
    public float doctorWalkingRepeatTime;
    public int numberOfTimes;

    public bool isGoneBack;
    public bool isAtReceptionArea;
    public bool canNPCFollow;
    //public Animation nPCAnimation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        isAtReceptionArea = false;
        canNPCFollow = false;

        InvokeRepeating("WalkAround", 1, doctorWalkingRepeatTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ReceptionAreaForDoc")
        {
            isAtReceptionArea = true;
            doctorAnimator.Play("Talking");
            Debug.Log("Collided with NPC");
        }
        else if (other.tag == "DoctorDesk")
        {
            isAtReceptionArea = false;
            isGoneBack = true;
        }
        else if (other.tag == "NPCStarter")
        {
            canNPCFollow = true;
            //numberOfTimes++;
            Debug.Log("No Times" + numberOfTimes);
        }
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
            yield return new WaitForSeconds(10);
            doctorAnimator.Play("Walking");
            agent.destination = wayback.position;
            isAtReceptionArea = false;
            isGoneBack = true;
        }
        yield return new WaitForSeconds(1);

        Debug.Log("Doctor is walking between two points");
    }

}
