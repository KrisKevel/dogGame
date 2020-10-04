using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletAction : MonoBehaviour, ActionScript
{
    public GameObject TabletPrefab;
    private GameObject TabletInstance;

    public void CleanAction()
    {
        GameObject.Destroy(TabletInstance);
        DogController.Instance.ResumeMovement();
    }

    public void PerformAction()
    {
        TabletInstance = GameObject.Instantiate(TabletPrefab, null);
        DogController.Instance.StopMovement();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
