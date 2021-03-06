﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DogBehaviour;

public class DogLoop : MonoBehaviour
{

    public static DogLoop DogLoopInstance;

    public GameObject EatingBowl;
    public GameObject SleepingPlace;
    public int ActionTimeout = 30;
    public int ActionCheckpoint = 10;

    public DogAction[] ActionsList =
    {
        DogAction.Eating,
        DogAction.Sleeping
    };

    private int _expectedActionIndex;

    private float _nextActionTime;
    private float _nextCheckTime;
    private bool _isChecked;
    private void updateTime()
    {
        Debug.Log("New action started! " + ActionsList[_expectedActionIndex]);
        switch (ActionsList[_expectedActionIndex])
        {
            case DogAction.Eating:
                //UIController.Instance.UpdateObjective("Get a snack!");
                break;
            case DogAction.Sleeping:
                //UIController.Instance.UpdateObjective("Take a nap!");
                break;
        }
    
        _nextActionTime = Time.time + ActionTimeout;
        _nextCheckTime = Time.time + ActionCheckpoint;
        _isChecked = false;
    }

    private void Start()
    {
        DogLoopInstance = this;
        _expectedActionIndex = 0;
        //updateTime();
    }

    public void StartTheLoop()
    {
        updateTime();
    }

    void Update()
    {
        if (UIController.Instance.IntroOver)
        {
            if (Time.time > _nextActionTime)
            {
                _expectedActionIndex = (_expectedActionIndex + 1) % ActionsList.Length;
                updateTime();
            }
            else if (Time.time > _nextCheckTime && !_isChecked)
            {
                _isChecked = true;
                if (Instance.CurrentAction != ActionsList[_expectedActionIndex])
                {
                    //Add to suspiciousness
                    Debug.Log("YOU ARE SUSPICIOUS!!!");
                    DogController.Instance.Suspicion += 0.1f;
                }
                else
                {
                    Debug.Log("Check passed, no sus!");
                }
            }
        }
    }
}
