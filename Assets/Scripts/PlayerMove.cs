using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float MaxX = 9f;
    private const float MaxY = 4f;
    public float speed = 3f;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -MaxX, MaxX),
            Mathf.Clamp(transform.position.y, -MaxY, MaxY)
        );
    }

    public void Move(float x, float y)
    {
        transform.Translate(new Vector3(x, y, 0).normalized * speed * Time.deltaTime);
    }
}