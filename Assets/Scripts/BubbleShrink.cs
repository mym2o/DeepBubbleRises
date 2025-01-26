using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BubbleShrink : MonoBehaviour
{
    public float shrinkRate = 0.1f; // Velocità con cui la bolla si restringe (unità per secondo)
    public float minScale = 0.2f; // Dimensione minima prima di distruggere la bolla
    public AudioSource audioSource; // Componente AudioSource per il suono

    private void Start()
    {
        // Controlla se l'AudioSource è stato assegnato
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource non assegnato!");
        }
    }

    void Update()
    {
        // Riduci la scala della bolla nel tempo
        transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;

        // Distruggi la bolla se raggiunge la dimensione minima
        if (transform.localScale.x <= minScale || transform.localScale.y <= minScale || transform.localScale.z <= minScale)
        {
            // Riproduci il suono
            if (audioSource != null && audioSource.clip != null)
            {
                Debug.Log("Here");
                audioSource.Play();
            }

            // Usa una coroutine per distruggere la bolla e ricaricare la scena
            StartCoroutine(DestroyBubbleAfterSound());
        }
    }

    // Coroutine per distruggere la bolla e ricaricare la scena dopo il suono
    IEnumerator DestroyBubbleAfterSound()
    {
        // Attendere che l'audio finisca
        yield return new WaitForSeconds(audioSource.clip.length);

        // Distruggi il GameObject
        Destroy(gameObject);

        // Ricarica la scena
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}