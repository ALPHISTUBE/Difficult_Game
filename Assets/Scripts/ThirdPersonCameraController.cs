using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    public float rotationSpeed = 5f;
    public float mouseSensitivity = 10f;
    public float minYAngle = -30f;
    public float maxYAngle = 60f;

    public Vector3 offset;
    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        offset = new Vector3(0, height, -distance);
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor in the game window
    }

    void LateUpdate()
    {
        if (target)
        {
            HandleMouseInput();
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 position = target.position + rotation * offset;

            transform.position = Vector3.Lerp(transform.position, position, 0.2f);
            transform.LookAt(target.position + Vector3.up * height);
        }
    }

    void HandleMouseInput()
    {
        currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    }
}
