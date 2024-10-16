using UnityEngine;

public class Player : MonoBehaviour
{

    [Tooltip("Movement speed for player.")]
    public float speed = 5f;
    [Tooltip("Jump force for player.")]
    public float jumpForce = 10f;

    private Rigidbody2D rb;

    private bool isJumping = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (isJumping) return;

        isJumping = true;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
