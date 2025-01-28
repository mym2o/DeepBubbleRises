using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BubbleShrink : MonoBehaviour
{
    public float shrinkRate = 0.1f; // Velocità con cui la bolla si restringe (unità per secondo)
    public float minScale = 0.1f; // Dimensione minima prima di distruggere la bolla
    public float shrinkRateDecrease = 0.01f; // Quantità di diminuzione del shrinkRate
    public float decreaseInterval = 1f; // Intervallo di tempo (in secondi) per diminuire il shrinkRate
    public AudioSource audioSource; // Componente AudioSource per il suono

    private bool isExploded = false;

    private void Start()
    {
        // Controlla se l'AudioSource è stato assegnato
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource non assegnato!");
        }
        StartCoroutine(DecreaseShrinkRate());
    }

    void Update()
    {
        // Riduci la scala della bolla nel tempo
        transform.localScale -= Vector3.one * shrinkRate * Time.deltaTime;

        // Distruggi la bolla se raggiunge la dimensione minima
        if (!isExploded && (transform.localScale.x <= minScale || transform.localScale.y <= minScale || transform.localScale.z <= minScale))
        {
            isExploded = true;
            // Riproduci il suono
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Usa una coroutine per distruggere la bolla e ricaricare la scena
            StartCoroutine(DestroyBubbleAfterSound());
        }
    }

    // Coroutine per diminuire il shrinkRate ogni tot secondi
    IEnumerator DecreaseShrinkRate()
    {
        while (shrinkRate > 0) // Continua finché shrinkRate è maggiore di 0
        {
            yield return new WaitForSeconds(decreaseInterval); // Attendi l'intervallo specificato
            shrinkRate = Mathf.Max(shrinkRate - shrinkRateDecrease, 0); // Diminuisci il shrinkRate ma non sotto 0
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