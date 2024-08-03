using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction controls = null;

    [SerializeField] private Vector2 movement = Vector2.zero;
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;

    void OnEnable() {
        controls.Enable();
    }
    
    void OnDisable() {
        controls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = controls.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(movement.x * moveSpeed, 0, movement.y * moveSpeed);
    }
}
