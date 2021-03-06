﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public static DogBehaviour Instance;

    public enum DogAction
    {
        Eating,
        Sleeping,
        Idling,
        Tablet
    }


    public DogAction CurrentAction = DogAction.Idling;


    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetAction(DogAction action)
    {
        CurrentAction = action;
        switch (action)
        {
            case DogAction.Eating:
                performEating();
                break;
            case DogAction.Sleeping:
                performSleeping();
                break;
            case DogAction.Tablet:
                performTablet();
                break;
            default:
                performIdling();
                break;
        }
    }

    public void SetAction(DogAction action, Vector3 targetPosition)
    {
        //transform.position = targetPosition; //this is causing weird teleportation
        SetAction(action);
    }

    public void UnsetAction()
    {
        SetAction(DogAction.Idling);
    }

    private void performIdling()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void performEating()
    {
        DogController.Instance.Chase = true;
        //GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void performSleeping()
    {
        DogController.Instance.Sleep();
        //GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void performTablet()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
