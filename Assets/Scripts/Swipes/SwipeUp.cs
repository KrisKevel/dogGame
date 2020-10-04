using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeUp : MonoBehaviour
{
    public float SwipeRange;

    private Vector3 startPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            if ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos).y > SwipeRange)
            {
                Swipe();
            }
        }
    }

    private void Swipe()
    {
        gameObject.SetActive(false);
    }
}
