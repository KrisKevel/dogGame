using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillianBehaviour : MonoBehaviour
{

    public int DefaultTimePerAction = 5;
    public int WorkTime = 10;
    public Vector3 WorkCoordinates = new Vector3(0, 3);
    public GameObject[] ActionSpots;
    public int[] ActionTimes;

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
            aipath.destination = _destination;
        }
    }

    private AIPath aipath;

    private int currentActionIndex = 0;
    private float NextActionTime = 0;

    private void Awake()
    {
        aipath = GetComponent<AIPath>();
    }

    void Start()
    {
        NextActionTime = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > NextActionTime)
        {
            if (currentActionIndex == ActionSpots.Length)
            {
                GoToWork();
                NextActionTime += WorkTime;
                currentActionIndex = 0;
            }
            else
            {
                destination = ActionSpots[currentActionIndex].transform.position;
                NextActionTime += currentActionIndex < ActionTimes.Length ? ActionTimes[currentActionIndex] : DefaultTimePerAction;
                currentActionIndex++;
            }
        }
        
    }

    void GoToWork()
    {
        destination = WorkCoordinates;
    }
}
