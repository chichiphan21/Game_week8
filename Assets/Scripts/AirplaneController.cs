
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirplaneController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 7f;
    public float horizontalSpeed = 5f;
    public float takeoffSpeed = 3f;
    public float maxHeight = 5f;

    [Header("Takeoff Settings")]
    public float takeoffHeight = 1.6f;

    public bool HasTakenOff { get; private set; }

    private Rigidbody rb;
    private float horizontalInput;
    private float forwardInput;
    private bool isClimbing;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.isKinematic = true;
    }

    void Update()
    {
        horizontalInput = 0f;
        forwardInput = 0f;

        // Tiến và lùi
        if (Input.GetKey(KeyCode.W))
            forwardInput = 1f;

        if (Input.GetKey(KeyCode.S))
            forwardInput = -1f;

        // Sang trái và phải
        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;

        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;

        // Cất cánh
        isClimbing = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(
            horizontalInput * horizontalSpeed,
            isClimbing ? takeoffSpeed : 0f,
            forwardInput * forwardSpeed
        );

        // Giới hạn tốc độ di chuyển
        Vector3 movement = direction * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + movement;

        // Không cho máy bay xuống dưới đường băng
        newPosition.y = Mathf.Clamp(
            newPosition.y,
            0.8f,
            maxHeight
        );

        rb.MovePosition(newPosition);

        // Đánh dấu máy bay đã cất cánh
        if (newPosition.y >= takeoffHeight)
        {
            HasTakenOff = true;
        }
    }
}
