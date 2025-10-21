using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 6f;
    public float jumpForce = 12f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        moveInput = Input.GetAxis("Horizontal");

        // Saltar si est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Aplicar movimiento f�sico
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // Comprobaci�n del suelo con SphereCast
        isGrounded = CheckGrounded();
    }

    bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            groundCheck.position,           // origen del c�rculo
            groundCheckRadius,              // radio del c�rculo
            Vector2.down,                   // direcci�n hacia abajo
            0.1f,                           // distancia
            groundLayer                     // capa del suelo
        );

        return hit.collider != null;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
