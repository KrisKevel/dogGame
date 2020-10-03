using UnityEngine;

public class Interactable : MonoBehaviour
{
    //Component for interactable objects in the scene
    public float Radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
