using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Характеристики")]
    [SerializeField] private float speed = 4;

    [Header("Компоненты")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody2D rb;

    private bool _isFacingRight = true;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = joystick.Horizontal * speed;
        float vertical = joystick.Vertical * speed;

        if (horizontal > 0 && !_isFacingRight)
            Flip();
        else if (horizontal < 0 && _isFacingRight)
            Flip();

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
