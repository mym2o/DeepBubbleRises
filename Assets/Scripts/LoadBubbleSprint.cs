using UnityEngine;

public class LoadBubbleSprint : MonoBehaviour
{
    public GameObject targetObject; // L'oggetto da ingrandire
    public float growthSpeed = 1f;  // Velocità di crescita dell'oggetto
    public Vector3 maxScale = new Vector3(3f, 3f, 3f); // Scala massima raggiungibile
    public float multiplier = 1f;
    public float maxDuration = 5f;

    private Vector3 initialScale;  // Scala iniziale dell'oggetto
    private bool isPressing = false; // Indica se il tasto è premuto
    private float pressDuration;

    private Vector3 sprintDirection;

    void Start()
    {
        // Memorizza la scala iniziale dell'oggetto
        if (targetObject != null)
        {
            initialScale = targetObject.transform.localScale;
        }
        sprintDirection = Vector3.zero;
    }

    void Update()
    {
        if (!isPressing && pressDuration > 0)
        {
            transform.position += sprintDirection * pressDuration * multiplier * Time.deltaTime;
            pressDuration -= Time.deltaTime;
        }

        // Quando il tasto viene premuto
        if (Input.GetKeyDown(KeyCode.Space) && targetObject != null && pressDuration <= 0f)
        {
            isPressing = true;
            pressDuration = 0f;
            sprintDirection = Vector3.zero;
        }

        // Durante la pressione del tasto
        if (Input.GetKey(KeyCode.Space) && isPressing && targetObject != null)
        {
            pressDuration += Time.deltaTime;
            pressDuration = Mathf.Clamp(pressDuration, 0f, maxDuration);

            // Calcola la nuova scala in base alla durata della pressione
            Vector3 newScale = targetObject.transform.localScale + Vector3.one * growthSpeed * Time.deltaTime;

            // Limita la scala massima
            targetObject.transform.localScale = Vector3.Min(newScale, maxScale);
        }

        // Quando il tasto viene rilasciato
        if (Input.GetKeyUp(KeyCode.Space) && targetObject != null && sprintDirection == Vector3.zero && pressDuration > 0f)
        {
            isPressing = false;

            targetObject.transform.localScale = initialScale;

            sprintDirection = transform.up;
        }
    }
}
