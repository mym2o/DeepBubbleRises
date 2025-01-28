using UnityEngine;

public class ChargingBubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float initialSpawnRate = 2f; // Frequenza di spawn
    public float spawnOffset = 10f; // Offset per spawnare dentro lo schermo
    public float screenHeight = 5f; // Altezza dello schermo in unità di mondo
    public float spawnHeightAboveBubble = 5f;
    public float spawnRateDecrease = 0.5f; // Quantità di riduzione della frequenza ogni minuto
    public float minimumSpawnRate = 0.5f; // Frequenza minima consentita
    public GameObject player;

    private float timeSinceLastSpawn = 0f;
    private float timeElapsed = 0f; // Tempo totale trascorso
    private float spawnRate; // Frequenza di spawn corrente

    void Start()
    {
        // Inizializza la frequenza di spawn con il valore iniziale
        spawnRate = initialSpawnRate;
    }

    void Update()
    {
        // Incrementa i timer
        timeSinceLastSpawn += Time.deltaTime;
        timeElapsed += Time.deltaTime;

        // Genera bolle a intervalli regolari
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnChargingBubble();
            timeSinceLastSpawn = 0f; // Resetta il timer di spawn
        }
    }

    void SpawnChargingBubble()
    {
        // Calcola la posizione di spawn
        float spawnX = Random.Range(-spawnOffset, spawnOffset);
        float spawnY = player.transform.position.y + spawnHeightAboveBubble + Random.Range(0f, 5f); // Fisso sopra la bolla + intervallo aggiuntivo

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        GameObject chargingBubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
    }
}