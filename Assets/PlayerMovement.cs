using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction controls = null;

    [SerializeField] private Vector2 movement = Vector2.zero;
    [SerializeField] private float moveSpeed;

    private SpriteRenderer sprite;
    private Rigidbody rb;
    private Animator animator;

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
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = controls.ReadValue<Vector2>();
        FlipSprite();
        HandleAnimator();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(movement.x * moveSpeed, 0, movement.y * moveSpeed);
    }

    private void FlipSprite() {
        sprite.flipX = movement.x <= 0.01 ;
    }

    private void HandleAnimator() {
        bool isMoving = Math.Abs(movement.x) > 0.01;
        animator.SetBool("isMoving", isMoving);
    }
}
