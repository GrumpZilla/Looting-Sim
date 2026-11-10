using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Variable Declaration

    
    // Average Human Walkspeed is 1.34 - 1.42 meters per second.
    [SerializeField] public float AWSL = 1.34f;
    [SerializeField] public float AWSU = 1.42f;
    [SerializeField] public float WalkSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 currentVelocity;
    [SerializeField] public float speedBoost;
    [SerializeField] public bool onMount = false;
    [SerializeField] public float acceleration = 1;

    [SerializeField] public float jumpHeight;


    // Temporary Variables
    public float previousPositionX = 0;


    // Player Object Declarations
    public GameObject MainBody;


    // Voids

    void Awake()
    {
        BirthStats();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(new Vector3(currentVelocity.x, 0, currentVelocity.y), ForceMode.Acceleration);
        Vector2 horizontal = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z);
        horizontal = Vector2.ClampMagnitude(horizontal, WalkSpeed);
        Vector3 velocity = new Vector3(horizontal.x, rb.linearVelocity.y, horizontal.y);
        rb.linearVelocity = velocity;
    }

    public void BirthStats()
    {
        // Generate WalkSpeed
        WalkSpeed = Random.Range(AWSL, AWSU);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
       currentVelocity = ctx.ReadValue<Vector2>().normalized * acceleration;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }
}
