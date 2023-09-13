using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFall : MonoBehaviour
{
    private Rigidbody[] rb;
    private NavMeshAgent agent;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rb) r.isKinematic = true;
    }

    public void TriggerRagdoll(bool state)
    {
        anim.enabled = !state; // inspector window animator enabled this code will disabled 
        foreach (Rigidbody r in rb) r.isKinematic = !state; // itrete and state (r) opposite value the kinematic value 
        agent.enabled = !state; // state will true the agent will false
    }
}
