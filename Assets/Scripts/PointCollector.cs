using TMPro;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = "" + Mathf.CeilToInt(player.transform.position.y);
    }
}
