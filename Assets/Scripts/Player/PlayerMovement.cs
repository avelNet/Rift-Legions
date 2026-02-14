using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Rigidbody rb;

    private Vector3 _moveDir;
    private bool _isRunning;

    public float currentSpeed;

    float horizontal;
    float vertical;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 _moveDir = camForward * vertical + camRight * horizontal;

        if (_moveDir.magnitude >= 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_moveDir);
            Quaternion smoothRotation = Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(smoothRotation);
            rb.MovePosition(rb.position + _moveDir * (moveSpeed * Time.deltaTime));
        }

        currentSpeed = _moveDir.magnitude;
    }
}
