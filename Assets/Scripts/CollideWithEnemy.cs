using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SphereTrigger : MonoBehaviour
{
    public event Action<Collider> OnObjectEnter;
    public event Action<Collider> OnObjectExit;

    [Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        OnObjectEnter?.Invoke(other); // Trigger eventt
        Destroy(transform.parent.gameObject);
        BackgroundMusic backgroundMusic = FindObjectOfType<BackgroundMusic>();
        if (backgroundMusic != null)
        {
            // Ottieni la scena attuale
            Scene currentScene = SceneManager.GetActiveScene();
            // Ricarica la scena
            SceneManager.LoadScene(currentScene.name);
            //backgroundMusic.StopMusic();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OnObjectExit?.Invoke(other); // Trigger event
    }
}