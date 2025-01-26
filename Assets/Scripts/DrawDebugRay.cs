using UnityEngine;

public class DrawDebugRay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up*10, Color.red);
    }
}
