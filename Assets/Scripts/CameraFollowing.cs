using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Riferimento al Transform del player
    public Vector3 offset; // Offset della camera rispetto al player
    public float smoothSpeed = 0.0125f; // Velocità di movimento della camera

    void LateUpdate()
    {
        if (player!=null)
        {
            // Calcola la posizione desiderata
            Vector3 desiredPosition = player.position + offset;

            // Interpola la posizione per un movimento più fluido
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Aggiorna la posizione della camera
            transform.position = smoothedPosition;

            // (Opzionale) Orienta la camera verso il player
            transform.LookAt(player);
        }
    }
}