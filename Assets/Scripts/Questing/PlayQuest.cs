using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayQuest : Quest
{
    void Awake()
    {
        questName = "Play!";
        goal = gameObject.AddComponent<Goal>();
        goal.countNeeded = 3;
        goal.quest = this;
    }

    private void Start()
    {
        UIController.Instance.AddObjective(questName);
    }

    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            goal.Increment(1);
        }
    }

    public override void Complete()
    {
        base.Complete();
        UIController.Instance.objectiveCompleted(questName);
    }
}
