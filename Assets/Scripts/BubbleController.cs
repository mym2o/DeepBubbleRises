using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocità di rotazione della bolla
    public float maxForce = 10f; // Forza massima applicabile al rilascio dello spazio
    public float chargeSpeed = 1f; // Velocità di caricamento della forza
    public float screenPadding = 0.5f; // Padding dello schermo per evitare che esca
    public Camera mainCamera; // Telecamera principale

    private float currentForce = 0f; // Forza corrente caricata
    private bool isCharging = false; // Indica se il tasto spazio è premuto
    private Rigidbody rb; // Riferimento al Rigidbody della bolla

    void Start()
    {
        // Recupera il Rigidbody
        rb = GetComponent<Rigidbody>();

        // Assicura che la telecamera sia assegnata
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        HandleRotation();
        HandleForceCharging();
        KeepBubbleOnScreen();
    }

    private void HandleRotation()
    {
        // Ottieni il movimento orizzontale del mouse
        float mouseDeltaX = Input.GetAxis("Mouse X");

        // Calcola la rotazione sull'asse X
        float rotationX = mouseDeltaX * rotationSpeed;

        // Aggiungi la rotazione, ma mantieni gli angoli limitati
        Vector3 currentEulerAngles = transform.eulerAngles;
        currentEulerAngles.x += rotationX;

        // Converti l'angolo in un range tra -180 e 180 gradi
        if (currentEulerAngles.x > 180) currentEulerAngles.x -= 360;

        // Limita la rotazione tra -90° e +90°
        currentEulerAngles.x = Mathf.Clamp(currentEulerAngles.x, -90f, 90f);

        // Applica la nuova rotazione limitata
        transform.eulerAngles = currentEulerAngles;

        Debug.DrawRay(transform.position, transform.forward * 100, Color.red);
    }

    private void HandleForceCharging()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Se il tasto è premuto, carica la forza
            isCharging = true;
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce); // Limita la forza alla forza massima
        }
        else if (isCharging)
        {
            // Se il tasto è rilasciato, applica la forza
            isCharging = false;
            FireBubble();
        }
    }

    private void FireBubble()
    {
        // Calcola la direzione della forza in base alla rotazione della bolla
        Vector3 forceDirection = transform.right; // L'asse "right" indica la direzione lungo X

        // Applica la forza al Rigidbody
        rb.AddForce(forceDirection * currentForce, ForceMode.Impulse);

        // Resetta la forza caricata
        currentForce = 0f;
    }

    private void KeepBubbleOnScreen()
    {
        // Ottieni la posizione della bolla in coordinate dello schermo
        Vector3 bubbleScreenPosition = mainCamera.WorldToScreenPoint(transform.position);

        // Controlla se è fuori dallo schermo e correggi
        if (bubbleScreenPosition.x < 0 + screenPadding)
        {
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(screenPadding, bubbleScreenPosition.y, bubbleScreenPosition.z));
        }
        else if (bubbleScreenPosition.x > Screen.width - screenPadding)
        {
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - screenPadding, bubbleScreenPosition.y, bubbleScreenPosition.z));
        }

        if (bubbleScreenPosition.y < 0 + screenPadding)
        {
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(bubbleScreenPosition.x, screenPadding, bubbleScreenPosition.z));
        }
        else if (bubbleScreenPosition.y > Screen.height - screenPadding)
        {
            transform.position = mainCamera.ScreenToWorldPoint(new Vector3(bubbleScreenPosition.x, Screen.height - screenPadding, bubbleScreenPosition.z));
        }
    }
}