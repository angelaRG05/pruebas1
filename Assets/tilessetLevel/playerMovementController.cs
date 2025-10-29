using TMPro;
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
    private Animator anim;
    private SpriteRenderer sr;

    public int monedas = 0;

    private void Awake()
    {
        // busca el componente del mismo objeto en el que se encuentra el script 
        anim = GetComponent<Animator>(); 
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    void Update()
    {
        // Movimiento horizontal
        moveInput = Input.GetAxis("Horizontal");
        bool running = Input.GetKey(KeyCode.LeftShift);

        // Saltar si est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Hacer flip en sp
        if (moveInput < 0)
        {
            sr.flipX = true;
        } else if (moveInput > 0) 
        {
            sr.flipX= false;
        }

        if (moveInput != 0)
        {
            anim.SetBool("Walk", true);
        }
        else if (moveInput == 0)
        {
            anim.SetBool("Walk", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Coin"))
        {
            Debug.Log("Ha conseguido la moneda collider");
            Destroy(collision.collider.gameObject);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            monedas++;
            Debug.Log("Ha conseguido la moneda trigger " + monedas);
            Destroy(collision.gameObject);

           
        }
    }





}
