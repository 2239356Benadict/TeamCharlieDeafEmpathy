using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoctorWalkingAround : MonoBehaviour
{
    public Transform[] points;
    public Transform wayback;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Animator doctorAnimator;
    public AnimationClip[] doctorAnimationClip;
    public float doctorWalkingRepeatTime;
    public bool isGoingBack;
    public bool isAtReceptionArea;
    //public Animation nPCAnimation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        isAtReceptionArea = false;
        InvokeRepeating("WalkAround", 1, doctorWalkingRepeatTime);
        
        //GotoNextPoint();
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
            isGoingBack = true;

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
            isGoingBack = true;
        }
        yield return new WaitForSeconds(1);

        Debug.Log("Doctor is walking between two points");
    }
    void Update()
    {

        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f && !reachedReceptionArea)
            //GotoNextPoint();

        //if (reachedReceptionArea)
        //{
        //    agent.destination = wayback.position;
        //}
    }
}
