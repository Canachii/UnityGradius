using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private const float MaxX = 9f;
    private const float MaxY = 4f;
    private const float Offset = 0.5f;
    
    public const float MaxSpeed = 5.5f;
    public float speed = 3f;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -MaxX, MaxX),
            Mathf.Clamp(transform.position.y, -MaxY + Offset, MaxY)
        );
    }

    public void Move(float x, float y)
    {
        _rigidbody.velocity = new Vector3(x, y, 0).normalized * speed;
    }
}