using UnityEngine;

public class ChargingBubble : MonoBehaviour
{
    public float lifeTime = 10f; // Tempo di vita in secondi

    void Start()
    {
        // Distruggi l'oggetto dopo il tempo di vita specificato
        Destroy(gameObject, lifeTime);
    }
}