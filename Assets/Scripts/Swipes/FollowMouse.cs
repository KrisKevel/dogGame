using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Bounds bounds = OrthographicBounds(Camera.main);

        mousePosition = new Vector3(
            Mathf.Clamp(mousePosition.x, bounds.min.x, bounds.max.x),
            Mathf.Clamp(mousePosition.y, bounds.min.y, bounds.max.y),
            0
        );
        transform.position = mousePosition;
    }

    // https://answers.unity.com/questions/501893/calculating-2d-camera-bounds.html
    public static Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
