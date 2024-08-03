using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction controls = null;

    [SerializeField] private Vector2 movement = Vector2.zero;
    [SerializeField] private float moveSpeed;

    private SpriteRenderer sprite;
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
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = controls.ReadValue<Vector2>();
        FlipSprite();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(movement.x * moveSpeed, 0, movement.y * moveSpeed);
    }

    private void FlipSprite() {
        sprite.flipX = movement.x > 0.01 ;
        
    }
}
