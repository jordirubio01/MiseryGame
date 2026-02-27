using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PaulMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private Vector3 InitialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        InitialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 1.45f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 1.45f))
        {
            Grounded = true;
            Animator.SetBool("grounded", true);
        }
        else
        {
            Grounded = false;
            Animator.SetBool("grounded", false);
        }

        // Horizontal movement
        Horizontal = 0.0f; // -1 if left, 0 if standing, 1 if right
        if (Keyboard.current.aKey.isPressed)
        {
            transform.localScale = new Vector3(-4.0f, 4.0f, 1.0f);
            Horizontal = -Speed;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            transform.localScale = new Vector3(4.0f, 4.0f, 1.0f);
            Horizontal = Speed;
        }
        Animator.SetBool("running", Horizontal != 0.0f);

        // Jump
        if (Keyboard.current.wKey.wasPressedThisFrame && Grounded)
            Jump();
    }

    void Jump()
    {
        Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, 0f);
        Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal, Rigidbody2D.linearVelocity.y);
    }

    public void Respawn()
    {
        transform.position = InitialPosition;
        Rigidbody2D.linearVelocity = Vector2.zero;
    }
}
