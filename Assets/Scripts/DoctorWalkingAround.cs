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
    public Animator guardAnimator;
    public AnimationClip[] doctorAnimationClip;
    public bool goback;
    public bool reachedReceptionArea;
    //public Animation nPCAnimation;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
        reachedReceptionArea = false;

    GotoNextPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ReceptionAreaForDoc")
        {
            reachedReceptionArea = true;
            guardAnimator.Play("Talking");
            Debug.Log("Collided with NPC");
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

    void GoToPreviousPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint - 1) % points.Length; 


    }

    void Update()
    {

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f && !reachedReceptionArea)
                GotoNextPoint();
        if (reachedReceptionArea)
        {
            agent.destination = wayback.position;
        }
        //if (goback)
        //{
        //    GoToPreviousPoint();
        //}
    }
}
