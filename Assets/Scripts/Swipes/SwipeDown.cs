using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDown : MonoBehaviour
{
    public float SwipeRange;

    private Vector3 startPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if ( - (Input.mousePosition - startPos).y > SwipeRange)
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
