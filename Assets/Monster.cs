using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [Tooltip("The player monster will target.")]
    public Transform player;
    [Tooltip("Movement speed for monster.")]
    public float speed = 5f;

    public int life = 3;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Damage();
        }
    }

    void Damage()
    {
        life = life - 1;

        if (life <= 0) Destroy(gameObject);
    }

}
