using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : Enemy
{
    public float groundPosition = -3;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        Physics2D.gravity = Vector2.down * 15f;

        Health.OnDead += () =>
        {
            _rb.isKinematic = true;
            _rb.velocity = Vector2.zero;
        };
    }

    protected override void Move()
    {
    }

    void FixedUpdate()
    {
        if (transform.position.y <= groundPosition)
        {
            _rb.velocity = GameManager.Instance.AimPlayer(transform.position) * speed;
        }
    }
}
