﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    

    public TextMeshProUGUI GoalPrefab;
    public GameObject ObjectivePanel;
    public Image SuspicionMeter;

    public Dictionary<string, TextMeshProUGUI> quests;

    private void Awake()
    {
        quests = new Dictionary<string, TextMeshProUGUI>();
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetSuspicious(float sus)
    {
        SuspicionMeter.fillAmount = sus;
    }

    public void UpdateObjective(string name)
    {
        if (ObjectivePanel.transform.childCount > 0)
        {
            Destroy(ObjectivePanel.transform.GetChild(0).gameObject);
            GoalPrefab.text = name;
            GameObject.Instantiate(GoalPrefab, ObjectivePanel.transform);
        }
        else AddObjective(name);
    }

    public void AddObjective(string name)
    {
        if (!quests.ContainsKey(name))
        {
            GoalPrefab.text = name;
            TextMeshProUGUI quest = GameObject.Instantiate(GoalPrefab, ObjectivePanel.transform);
            quests.Add(name, quest);
        }
    }

    public void objectiveCompleted(string name)
    {
        if (quests.ContainsKey(name))
        {
            TextMeshProUGUI quest;
            quests.TryGetValue(name, out quest);
            GameObject.Destroy(quest.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
