using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    private const float Speed = 2f;
    
    private void Update()
    {
        transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked up item");
            Destroy(gameObject);
        }
    }
}