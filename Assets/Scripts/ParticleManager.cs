using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().IsAlive())
        {
            // Ricarica la scena corrente
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
