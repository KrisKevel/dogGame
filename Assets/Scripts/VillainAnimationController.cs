using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainAnimationController : MonoBehaviour
{
    AIPath aipath;
    Animator animator;

    private void Awake()
    {
        aipath = GetComponentInParent<AIPath>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", aipath.desiredVelocity.x);
        animator.SetFloat("Vertical", aipath.desiredVelocity.y);
        animator.SetFloat("Speed", aipath.desiredVelocity.magnitude);
    }
}
