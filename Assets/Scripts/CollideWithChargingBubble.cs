using UnityEngine;

public class CollideWithChargingBubble : MonoBehaviour
{
    public float growthRate = 0.1f; // Incremento della scala per ogni collisione
    public string bubbleTag = "Bubble"; // Tag delle bolle spawnate

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se la bolla ha il tag corretto
        if (other.CompareTag(bubbleTag))
        {
            Debug.Log("Bubble absorbed!");
            // Incrementa la scala della bolla principale
            transform.localScale += Vector3.one * growthRate;

            // Distruggi la bolla con cui è avvenuta la collisione
            Destroy(other.gameObject);
        }
    }
}