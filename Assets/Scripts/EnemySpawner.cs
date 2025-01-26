using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del nemico
    public float spawnRate = 2f; // Frequenza di spawn
    public float spawnOffset = 10f; // Offset per spawnare fuori dallo schermo
    public float screenHeight = 5f; // Altezza dello schermo in unità di mondo
    public float spawnHeightAboveBubble = 5f;

    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        // Incrementa il timer
        timeSinceLastSpawn += Time.deltaTime;

        // Genera nemici a intervalli regolari
        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f; // Resetta il timer
        }
    }

    void SpawnEnemy()
    {
        // Determina se il nemico arriva da destra o sinistra
        bool fromRight = Random.Range(0, 2) == 0;

        // Calcola la posizione di spawn
        float spawnX = fromRight ? spawnOffset : -spawnOffset;
        //float spawnY = Random.Range(transform.position.y, transform.position.y + screenHeight);
        float spawnY = transform.position.y + spawnHeightAboveBubble + Random.Range(0f, 5f); // Fisso sopra la bolla + intervallo aggiuntivo

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        // Instanzia il nemico
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Configura la direzione del nemico
        float direction = fromRight ? -1f : 1f;
        enemy.GetComponent<FishMovement>().SetDirection(direction);
    }
}