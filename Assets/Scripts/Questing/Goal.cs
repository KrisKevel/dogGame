using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int countNeeded;
    public int countCurrent;
    public bool completed;
    public Quest quest;

    /*public Goal(int countNeeded, Quest quest)
    {
        this.countNeeded = countNeeded;
        countCurrent = 0;
        completed = false;
        this.quest = quest;
    }*/

    public void Increment(int amount)
    {
        countCurrent = Mathf.Min(countCurrent + 1, countNeeded);
        if(countCurrent >= countNeeded && !completed)
        {
            this.completed = true;
            Debug.Log("COMPELTED");
            quest.Complete();
        }
    }
}
