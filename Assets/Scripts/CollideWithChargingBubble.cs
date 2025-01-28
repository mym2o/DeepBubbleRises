using UnityEngine;

public class CollideWithChargingBubble : MonoBehaviour
{
    public float growthRate = 0.1f; // Incremento della scala per ogni collisione
    public string bubbleTag = "Bubble"; // Tag delle bolle spawnate
    public SphereCollider sphereCollider;


    private void OnTriggerEnter(Collider other)
    {
        // Controlla se la bolla ha il tag corretto
        if (other.CompareTag(bubbleTag))
        {
            // Incrementa la scala della bolla principale
            transform.localScale += Vector3.one * growthRate;
            sphereCollider.radius = 0.5f * transform.localScale.x; // Radius adattato alla nuova scala

            // Distruggi la bolla con cui è avvenuta la collisione
            Destroy(other.gameObject);
        }
    }
}