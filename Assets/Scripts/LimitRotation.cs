using UnityEngine;

public class LimitRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocità di rotazione in gradi al secondo
    public float minAngle = -45f; // Angolo minimo consentito
    public float maxAngle = 45f; // Angolo massimo consentito
    public Vector3 MovementDirection = Vector3.zero;

    private float currentRotation = 0f; // Angolo corrente

    void Update()
    {
        // Calcola la nuova rotazione
        float rotation = rotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X");

        // Aggiungi la rotazione alla rotazione corrente
        currentRotation += rotation;

        // Limita l'angolo tra minAngle e maxAngle
        currentRotation = Mathf.Clamp(currentRotation, minAngle, maxAngle);

        // Ruota l'oggetto solo attorno all'asse Z
        transform.rotation = Quaternion.Euler(currentRotation * MovementDirection);
    }
}
