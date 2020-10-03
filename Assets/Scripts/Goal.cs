using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goals of the player listed

public abstract class Goal : MonoBehaviour
{
    public string name;
    public abstract bool IsAchieved();
    public abstract void Complete();
    public abstract void DrawHUD();
}

public class GoalManager : MonoBehaviour
{

    public Goal[] goals;

    void Awake()
    {
        goals = GetComponents<Goal>();
    }

    void OnGUI()
    {
        //UIController.SetObjectives(goals);
    }

    void Update()
    {
        foreach (var goal in goals)
        {
            if (goal.IsAchieved())
            {
                goal.Complete();
                Destroy(goal);
            }
        }
    }
}

class Eat : Goal
{
    public override bool IsAchieved()
    {
        return false;
    }

    public override void Complete()
    {
        
    }

    public override void DrawHUD()
    {
        
    }
}

class Nap : Goal
{
    public override bool IsAchieved()
    {
        return false;
    }

    public override void Complete()
    {
        
    }

    public override void DrawHUD()
    {
        
    }
}

class Play : Goal
{
    public override bool IsAchieved()
    {
        return false;
    }

    public override void Complete()
    {
        
    }

    public override void DrawHUD()
    {
        
    }
}

class Bark : Goal
{
    public override bool IsAchieved()
    {
        return false;
    }

    public override void Complete()
    {
        
    }

    public override void DrawHUD()
    {
        
    }
}

class ChaseTail : Goal
{
    public override bool IsAchieved()
    {
        return false;
    }

    public override void Complete()
    {
        
    }

    public override void DrawHUD()
    {
        
    }
}
