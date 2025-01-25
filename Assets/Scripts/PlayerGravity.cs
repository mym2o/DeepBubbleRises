using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    public float buoyancyForce = 10f; // Forza di galleggiamento
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = true;
        rb.linearDamping = 2f;
        rb.angularDamping = 2f;
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.up * buoyancyForce, ForceMode.Force);
    }
}