using UnityEngine;

public class Monster : MonoBehaviour
{
    [Tooltip("The player monster will target.")]
    public Transform player;
    [Tooltip("Movement speed for monster.")]
    public float speed = 5f;
    public float life = 3f;

    private HealthBar healthBar;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxLife(life);
        healthBar.SetAnchor(transform);
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player == null) return;

        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        life = life - 1;

        healthBar.TakeDamage(1);

        if (life <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
