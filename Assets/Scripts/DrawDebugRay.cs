using UnityEngine;

public class DrawDebugRay : MonoBehaviour
{
    public GameObject explosionPS;
    public GameObject meshGo;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up*10, Color.red);

        if (Input.GetKeyDown(KeyCode.P))
        {
            explosionPS.SetActive(true);
            meshGo.SetActive(false);
        }
    }
}
