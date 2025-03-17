using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] Vector3 velocity;
    [SerializeField] Vector3 spin;

    bool isKicked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isKicked)
        {
            Kick();
            isKicked = true;
        }
    }

    void FixedUpdate()
    {
        if (isKicked)
        {
            ApplyMagnusEffect();
        }
    }

    void Kick()
    {
        rb.linearVelocity = velocity; 
        rb.angularVelocity = spin;
    }

    void ApplyMagnusEffect()
    {
        Vector3 magnusForce = Vector3.Cross(rb.linearVelocity, rb.angularVelocity);
        rb.AddForce(magnusForce, ForceMode.Force);
    }
}