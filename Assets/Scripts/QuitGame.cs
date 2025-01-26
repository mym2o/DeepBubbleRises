using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;

    private PlayerGravity playerGravity;
    private Rigidbody playerRb;
    private LoadBubbleSprint loadBubbleSprint;
    private LimitRotation limitRotation;

    private void Awake()
    {
        playerGravity = player.GetComponent<PlayerGravity>();
        playerRb = player.GetComponent<Rigidbody>();
        loadBubbleSprint = player.GetComponent<LoadBubbleSprint>();
        limitRotation = player.GetComponent<LimitRotation>();

        playerGravity.buoyancyForce = 0f;
        playerRb.useGravity = false;
        loadBubbleSprint.enabled = false;
        limitRotation.enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void NewGame()
    {
        limitRotation.enabled = true;
        loadBubbleSprint.enabled = true;
        playerRb.useGravity = true;
        playerGravity.buoyancyForce = 10f;
        canvas.SetActive(false);
    }
}
