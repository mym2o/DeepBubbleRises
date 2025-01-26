using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 5f; // Velocità di movimento
    private float direction = 1f; // Direzione del movimento (-1 per sinistra, 1 per destra)

    public void SetDirection(float dir)
    {
        direction = dir;

        // Ruota il pesce per orientarlo nella direzione corretta
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * direction;
        transform.localScale = localScale;
    }

    void Update()
    {
        // Muovi il nemico nella direzione impostata
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // Distruggi il nemico quando esce dallo schermo
        if (Mathf.Abs(transform.position.x) > 15f) // Valore basato sul tuo offset
        {
            Destroy(gameObject);
        }
    }
}