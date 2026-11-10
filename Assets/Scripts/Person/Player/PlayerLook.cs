using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] public float horizontalSensitivity = 100f;
    [SerializeField] public float verticalSensitivity = 100f;
    public Vector2 lookInput;
    [SerializeField] private float lLimitLookY = 0;
    [SerializeField] private float uLimitLookY = Mathf.PI / 2;
    public GameObject cameraCore;
    public GameObject MainBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        lookInput = ctx.ReadValue<Vector2>();
        float mouseX = lookInput.x * horizontalSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * verticalSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        cameraCore.transform.Rotate(Vector3.right * mouseY);
        if (cameraCore.transform.rotation.x > uLimitLookY)
        {
            cameraCore.transform.rotation = Quaternion.Euler(uLimitLookY, 0, 0);
        }
    }

}
