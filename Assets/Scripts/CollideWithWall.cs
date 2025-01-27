using UnityEngine;
using UnityEngine.Audio;

public class CollideWithWall : MonoBehaviour
{
    public GameObject particleSystem;
    public AudioSource audioSource; // Componente AudioSource per il suono

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (!IsPlayerVisible())
        {
            GameObject instantiated = GameObject.Instantiate(particleSystem, player.transform);
            instantiated.transform.SetParent(null);
            // Riproduci il suono
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }

            player.SetActive(false);
        }
    }

    private bool IsPlayerVisible()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null || player == null)
            return false;

        // Converti la posizione del player in coordinate della viewport
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(player.transform.position);

        // Controlla se il player è visibile
        bool isVisible = viewportPos.z > 0 && // Davanti alla camera
                         viewportPos.x >= 0 && viewportPos.x <= 1 && // X all'interno del viewport
                         viewportPos.y >= 0 && viewportPos.y <= 1;   // Y all'interno del viewport

        return isVisible;
    }
}
