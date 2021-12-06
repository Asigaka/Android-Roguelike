using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4;

    [Header("Components")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody2D rb;

    private PlayerCombat _combat;
    private bool _isFacingRight = true;

    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _combat = PlayerCombat.Instance;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _horizontal = joystick.Horizontal * speed;
        _vertical = joystick.Vertical * speed;

        Vector2 movement = new Vector2(_horizontal, _vertical);
        rb.velocity = movement;
    }

    private void Rotate()
    {
        if (_combat.MainTarget == null)
        {
            if (_horizontal > 0 && !_isFacingRight)
                Flip();
            else if (_horizontal < 0 && _isFacingRight)
                Flip();
        }
        else
        {
            Vector2 direction = transform.position - _combat.MainTarget.position;

            if (direction.x < 0 && !_isFacingRight)
            {
                //_combat.WeaponFlip();
                Flip();
            }
            else if (direction.x > 0 && _isFacingRight)
            {
                //_combat.WeaponFlip();
                Flip();
            }
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
