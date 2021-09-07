using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 6);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log(collision.name);
            Destroy(gameObject);
        }
    }
}
