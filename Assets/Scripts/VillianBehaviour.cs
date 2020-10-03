using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillianBehaviour : MonoBehaviour
{

    private Vector3 _destination;
    public Vector3 destination
    {
        get
        {
            return _destination;
        }
        set
        {
            _destination = value;
            MoveToDestination();
        }
    }

    private AIPath aipath;

    private void MoveToDestination()
    {
        aipath.destination = _destination;   
    }

    private void Awake()
    {
        aipath = GetComponent<AIPath>();
    }

    void Start()
    {
        destination = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
