using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public Goal goal;
    public bool completed;

    public virtual void Complete()
    {
        Debug.Log("Quest completed");
        Reward();
    }

    public void Reward()
    {
        Debug.Log("You are less suspicious");
        Destroy(this);
    }
}
