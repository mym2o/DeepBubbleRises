using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del nemico
    public float initialSpawnRate = 2f; // Frequenza di spawn iniziale
    public float spawnOffset = 10f; // Offset per spawnare fuori dallo schermo
    public float screenHeight = 5f; // Altezza dello schermo in unità di mondo
    public float spawnHeightAboveBubble = 5f;
    public float spawnRateDecrease = 0.5f; // Quantità di riduzione della frequenza ogni minuto
    public float minimumSpawnRate = 0.5f; // Frequenza minima consentita

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

        // Controlla se è tempo di ridurre la frequenza di spawn
        if (timeElapsed >= 60f) // Ogni minuto
        {
            DecreaseSpawnRate();
            timeElapsed = 0f; // Resetta il timer per la diminuzione
        }

        // Genera nemici a intervalli regolari
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f; // Resetta il timer di spawn
        }
    }

    void DecreaseSpawnRate()
    {
        // Riduce la frequenza di spawn ma non scende sotto il minimo
        spawnRate = Mathf.Max(spawnRate - spawnRateDecrease, minimumSpawnRate);
        Debug.Log($"Spawn rate decreased to: {spawnRate}s");
    }

    void SpawnEnemy()
    {
        // Determina se il nemico arriva da destra o sinistra
        bool fromRight = Random.Range(0, 2) == 0;

        // Calcola la posizione di spawn
        float spawnX = fromRight ? spawnOffset : -spawnOffset;
        float spawnY = transform.position.y + spawnHeightAboveBubble + Random.Range(0f, 5f); // Fisso sopra la bolla + intervallo aggiuntivo

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        // Instanzia il nemico
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Configura la direzione del nemico
        float direction = fromRight ? -1f : 1f;
        enemy.GetComponent<FishMovement>().SetDirection(direction);
    }
}