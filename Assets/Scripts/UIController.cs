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
    public GameObject NarrativePanel;
    public Image SuspicionMeter;
    public TextMeshProUGUI Narrative;
    public float TimeToRead = 15;

    public Dictionary<string, TextMeshProUGUI> quests;
    public Dictionary<int, string> narrative;

    public bool IntroOver = false;

    private float timeToRead;
    private int currentNarr;

    private void Awake()
    {
        quests = new Dictionary<string, TextMeshProUGUI>();
        Instance = this;
        
        narrative = new Dictionary<int, string>();
        narrative.Add(0, "Being a dog isn't easy, is it? Day after day it's all the same - ");
        narrative.Add(1, "eat, sleep, eventually chase own tail and wait for the owner to come back from work.");
        narrative.Add(2, "(what are they even doing there? weird fellas)");
        narrative.Add(3, "But you know, some dogs are really, really different. You don't believe me?");
        narrative.Add(4, "Well, let me introduce you to Rex.");
        narrative.Add(5, "Now don't get me wrong, he still absolutely has to do 'the dog things'");
        narrative.Add(6, "but there is something bigger, something more important, a mission!");
        narrative.Add(7, "You see, Rex's owner doesnt have a regular job - he is making a living by smuggling something illegal");
        narrative.Add(8, "across the border. Rex was sent to him by a spy agency and has lived undercover for months");
        narrative.Add(9, "and now that he knows the owner doesn't suspect a thing, it's time to finally get going with the investigation");
        narrative.Add(10, "while still maintaining the regular dog schedule, of course...");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentNarr = -1;
        timeToRead = 0;

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

        if(timeToRead <= 0)
        {
            if (NarrativePanel.transform.childCount > 0)
            {
                Destroy(NarrativePanel.transform.GetChild(0).gameObject);
            }
            
            narrative.TryGetValue(++currentNarr, out string nar);
            Narrative.text = nar;
            GameObject.Instantiate(Narrative, NarrativePanel.transform);
            timeToRead = TimeToRead;

        }
        else if(currentNarr > 10) { 
            if (!IntroOver) { 
                IntroOver = true;
                DogLoop.DogLoopInstance.StartTheLoop();
            } 
        }

        timeToRead -= Time.deltaTime;
    }
}
