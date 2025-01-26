using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour
{
    public BackgroundMusic backgroundMusic;
    public GameObject particleSystem;
    public AudioSource audioSource; // Componente AudioSource per il suono

    private GameObject playerToDestroy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<SphereCollider>() != null)
        {
            playerToDestroy = other.gameObject.transform.parent.gameObject;
            GameObject instantiated = GameObject.Instantiate(particleSystem, playerToDestroy.transform);
            instantiated.transform.SetParent(null);
            // Riproduci il suono
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            playerToDestroy.SetActive(false);
            //// Ritarda la ricarica della scena per la durata del suono
            //float audioDuration = audioSource.clip.length;
            //Invoke("ReloadScene", audioDuration); // Ritarda la ricarica della scena per la durata del suono
        }
    }
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}