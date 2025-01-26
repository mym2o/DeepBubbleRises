using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CollideWithEnemy : MonoBehaviour
{
    public BackgroundMusic backgroundMusic;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") && other.GetComponent<SphereCollider>() != null)
        {
            Destroy(other.gameObject);

            // Ottieni la scena attuale
            Scene currentScene = SceneManager.GetActiveScene();
            // Ricarica la scena
            SceneManager.LoadScene(currentScene.name);
        }
    }

}