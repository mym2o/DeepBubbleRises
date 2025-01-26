using UnityEngine;

public class BubbleShrink : MonoBehaviour
{
    public float shrinkRate = 0.1f; // Velocit� con cui la bolla si restringe (unit� per secondo)
    public float minScale = 0.2f; // Dimensione minima prima di distruggere la bolla

    void Update()
    {
        // Riduci la scala della bolla nel tempo
        transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;

        // Distruggi la bolla se raggiunge la dimensione minima
        if (transform.localScale.x <= minScale || transform.localScale.y <= minScale || transform.localScale.z <= minScale)
        {
            Destroy(gameObject);
        }
    }
}