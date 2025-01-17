using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class BasketballBounce : MonoBehaviour
{
    [Header("Bounce Settings")]
    [Range(0, 1)] public float bounceFactor = 0.8f; // Determines energy retained (0-1, where 1 is full retention)
    public float gravityScale = 1.0f; // Scales gravity applied to the ball
    public float minimumBounceVelocity = 0.1f; // Minimum velocity to stop bouncing
    [SerializeField] private AudioSource bounceSound;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // We'll apply custom gravity
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // Better collision handling for fast-moving objects
    }

    void FixedUpdate()
    {
        // Apply custom gravity
        Vector3 gravity = Physics.gravity * gravityScale;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceSound.Play();
        // Calculate the bounce only if the collision has enough impact velocity
        if (collision.relativeVelocity.magnitude > minimumBounceVelocity)
        {
            Vector3 velocity = rb.velocity;

            // Reverse velocity along the collision normal (with bounce factor applied)
            Vector3 normal = collision.contacts[0].normal;
            Vector3 bounce = Vector3.Reflect(velocity, normal) * bounceFactor;

            rb.velocity = bounce;
        }
        else
        {
            // Stop movement if velocity is too low
            rb.velocity = Vector3.zero;
        }
    }
}