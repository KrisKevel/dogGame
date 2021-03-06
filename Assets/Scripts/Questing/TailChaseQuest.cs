﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailChaseQuest : Quest
{
    void Awake()
    {
        questName = "Chase your tail!";
        goal = gameObject.AddComponent<Goal>();
        goal.countNeeded = 3;
        goal.quest = this;
    }

    private void Start()
    {
        UIController.Instance.AddObjective(questName);
    }

    public override void Complete()
    {
        base.Complete();
        UIController.Instance.objectiveCompleted(questName);
    }
}
