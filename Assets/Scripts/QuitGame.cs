using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;

    private PlayerGravity playerGravity;
    private Rigidbody playerRb;
    private LoadBubbleSprint loadBubbleSprint;
    private LimitRotation limitRotation;
    private BubbleShrink bubbleShrink;

    private void Awake()
    {
        playerGravity = player.GetComponent<PlayerGravity>();
        playerRb = player.GetComponent<Rigidbody>();
        loadBubbleSprint = player.GetComponent<LoadBubbleSprint>();
        limitRotation = player.GetComponent<LimitRotation>();
        bubbleShrink = player.GetComponent<BubbleShrink>();

        bubbleShrink.shrinkRate = 0f;
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
        bubbleShrink.shrinkRate = 0.01f;
        panel.SetActive(false);
    }
}
