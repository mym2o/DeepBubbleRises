using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Riferimento al player
    public Vector3 offset;          // Offset della camera rispetto al player
    public float smoothSpeed = 0.125f; // Velocità di interpolazione
    public float snapThreshold = 2f;  // Soglia oltre la quale la camera si muove più velocemente per recuperare lo scatto

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcola la posizione desiderata della camera
            Vector3 desiredPosition = player.position + offset;

            // Controlla se la distanza verticale supera la soglia
            float verticalDistance = Mathf.Abs(desiredPosition.y - transform.position.y);
            float currentSmoothSpeed = smoothSpeed;

            if (verticalDistance > snapThreshold)
            {
                // Se la distanza è troppo grande, aumenta la velocità di interpolazione
                currentSmoothSpeed = Mathf.Lerp(smoothSpeed, 1f, verticalDistance / snapThreshold);
            }

            // Interpola la posizione della camera verso la posizione desiderata
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, currentSmoothSpeed * Time.deltaTime);

            // Aggiorna solo la posizione verticale della camera per mantenere l'offset orizzontale e la profondità
            transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
        }
    }
}