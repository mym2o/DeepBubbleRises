using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    private AudioSource audioSource;

    void Awake()
    {
        // Controlla se esiste già un'istanza
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantieni l'oggetto tra le scene
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject); // Distruggi l'oggetto duplicato
        }
    }

    // Metodo per fermare la musica
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}