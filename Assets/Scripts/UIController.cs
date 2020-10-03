using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    public TextMeshProUGUI GoalPrefab;
    public GameObject ObjectivePanel;
    //public Image SuspicionMeter;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetSuspicious(float sus)
    {
        //Set a value to the susect meter
    }

    public void SetObjectives(Goal[] goals)
    {
        foreach (Goal goal in goals) {
            GoalPrefab.text = goal.name;
            GameObject.Instantiate(GoalPrefab, ObjectivePanel.transform);
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
