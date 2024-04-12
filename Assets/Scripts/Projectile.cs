using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public Vector2 direction = Vector2.right;
    public string target = "Enemy";
    public bool penetrate;

    protected virtual void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(target) && other.GetComponent<Health>())
        {
            other.GetComponent<Health>().TakeDamage(1);
            gameObject.SetActive(penetrate);
        }

        if (other.CompareTag("Untagged"))
        {
            gameObject.SetActive(penetrate);
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}