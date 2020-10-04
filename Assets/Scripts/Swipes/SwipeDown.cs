using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDown : MonoBehaviour
{
    public float SwipeRange;
    public GameObject blocker;

    private Vector3 startPos;

    void Update()
    {
        if (blocker == null || !blocker.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (-(Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPos).y > SwipeRange)
                {
                    Swipe();
                }
            }
        }
    }

    private void Swipe()
    {
        gameObject.SetActive(false);
    }
}
