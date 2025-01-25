using UnityEngine;

public class SkyboxTintChange : MonoBehaviour
{
    public Color InitialColor;
    public Color TargetColor;
    public float ChangeSpeed = .01f;

    public GameObject Player;

    void Start()
    {
        if (RenderSettings.skybox.HasProperty("_Tint"))
        {
            RenderSettings.skybox.SetColor("_Tint", InitialColor);
        }
    }

    void FixedUpdate()
    {
        if (RenderSettings.skybox != null && RenderSettings.skybox.HasProperty("_Tint") && Player != null && Player.activeSelf)
        {
            Color currentColor = RenderSettings.skybox.GetColor("_Tint");
            Color newColor = Color.Lerp(currentColor, TargetColor, ChangeSpeed * Time.deltaTime);
            RenderSettings.skybox.SetColor("_Tint", newColor);
        }
    }
}
