using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DogBehaviour;

public class DogLoop : MonoBehaviour
{

    public GameObject EatingBowl;
    public GameObject SleepingPlace;
    public int ActionTimeout = 30;
    public int ActionCheckpoint = 10;

    public DogAction[] ActionsList =
    {
        DogAction.Eating,
        DogAction.Sleeping
    };

    public EatQuest eatQuest;
    public SleepQuest sleepQuest;
    public Quest currentQuest;

    private int _expectedActionIndex;

    private float _nextActionTime;
    private float _nextCheckTime;
    private bool _isChecked;
    private void updateTime()
    {
        Debug.Log("New action started! " + ActionsList[_expectedActionIndex]);
        switch (_expectedActionIndex)
        {
            case 0:
                currentQuest =  gameObject.AddComponent<EatQuest>();
                break;
            case 1:
                currentQuest = gameObject.AddComponent<SleepQuest>();
                break;
        }
    
        _nextActionTime = Time.time + ActionTimeout;
        _nextCheckTime = Time.time + ActionCheckpoint;
        _isChecked = false;
    }

    private void Start()
    {
        _expectedActionIndex = 0;
        updateTime();
    }

    void Update()
    {
        if (Time.time > _nextActionTime)
        {
            _expectedActionIndex = (_expectedActionIndex + 1) % ActionsList.Length;
            updateTime();
        } else if (Time.time > _nextCheckTime && !_isChecked)
        {
            _isChecked = true;
            if (Instance.CurrentAction != ActionsList[_expectedActionIndex])
            {
                //Add to suspiciousness
                Debug.Log("YOU ARE SUSPICIOUS!!!");
            } else
            {
                Debug.Log("Check passed, no sus!");
            }
            currentQuest.Complete();
        }
    }
}
