using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Health : MonoBehaviour
{
    [HideInInspector] public bool isDead;
    public int maxHealth = 1;
    [HideInInspector] public int health = 1;

    public Action OnDead;

    private Collider2D _collider;
    private SpriteRenderer _sprite;

    public void Reset()
    {
        isDead = false;
        health = maxHealth;
        StartCoroutine("Blink");
    }

    private void Start()
    {
        isDead = false;
        health = maxHealth;
        _collider = GetComponent<Collider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health <= 0)
        {
            _collider.enabled = false;
            isDead = true;
            OnDead?.Invoke();
        }
    }
    
    private IEnumerator Blink()
    {
        const int time = 5;
        
        for (int i = 0; i < time; i++)
        {
            _sprite.color = Color.clear;
            yield return new WaitForSeconds(1f / (time * 2));
            _sprite.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(1f / (time * 2));
        }
        _sprite.color = Color.white;
        _collider.enabled = true;
    }
}