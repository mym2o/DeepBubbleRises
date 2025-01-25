using UnityEngine;

public class LimitRotation : MonoBehaviour
{
    public Transform target; // L'oggetto a cui vuoi confrontare la rotazione
    public float maxAngle = 45f; // Angolo massimo consentito in gradi

    void Update()
    {
        // Ottieni la rotazione corrente del tuo oggetto (ad esempio, della fotocamera o di un altro oggetto)
        Quaternion currentRotation = transform.rotation;

        // Calcola il prodotto scalare tra le due rotazioni
        float dot = Quaternion.Dot(currentRotation, target.rotation);

        // Calcola l'angolo tra le due rotazioni usando il prodotto scalare
        float angle = Mathf.Acos(dot) * 2f * Mathf.Rad2Deg;

        // Verifica se l'angolo è maggiore del limite
        if (angle > maxAngle)
        {
            Debug.Log("Rotazione troppo grande, fermati!");
            // Puoi qui gestire cosa fare se l'angolo è troppo grande (ad esempio, fermare la rotazione)
        }
        else
        {
            Debug.Log("Rotazione consentita");
            // Procedi con la rotazione
        }
    }
}
