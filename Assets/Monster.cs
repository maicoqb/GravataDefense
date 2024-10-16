using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [Tooltip("The player monster will target.")]
    public Transform player;
    [Tooltip("Movement speed for monster.")]
    public float speed = 5f;

    public Image healthBarFill;
    public float maxLife = 3;
    private float life;
    private Vector3 healthBarOffset;
    public Transform healthBarBackground;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        life = maxLife;
        healthBarOffset = healthBarBackground.position - transform.position;
    }

    void Update()
    {
        FollowPlayer();

        healthBarBackground.position = transform.position + healthBarOffset;
        healthBarBackground.rotation = Quaternion.identity;
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

        float healthPercent = life / maxLife;
        healthBarFill.transform.localScale = new Vector3(healthPercent, healthBarFill.transform.localScale.y, healthBarFill.transform.localScale.z);

        if (life <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
