using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CollideWithEnemy : MonoBehaviour
{
    public BackgroundMusic backgroundMusic;
    public AudioSource audioSource; // Componente AudioSource per il suono

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<SphereCollider>() != null)
        {
            // Riproduci il suono
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            // Distruggi il player
            Destroy(other.gameObject);

            // Ritarda la ricarica della scena per la durata del suono
            float audioDuration = audioSource.clip.length;
            Invoke("ReloadScene", audioDuration); // Ritarda la ricarica della scena per la durata del suono
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}