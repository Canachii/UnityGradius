using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMove), typeof(Health))]
public class Player : MonoBehaviour
{
    public GameObject missile;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject laser;
    public GameObject option;
    public GameObject shield;

    private PlayerInput _input;
    private PlayerMove _move;
    private Health _health;
    private Animator _animator;
    private SpriteRenderer _sprite;

    private bool _missile;
    private bool _laser;
    private bool _double;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _move = GetComponent<PlayerMove>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();

        _health.OnDead += () =>
        {
            _animator.SetBool("Dead", true);
            GameManager.Instance.PlaySFX("Dead");
        };

        NewPower();
    }

    private void NewPower()
    {
        missile = Instantiate(missile);
        bullet1 = Instantiate(bullet1);
        bullet2 = Instantiate(bullet2);
        laser = Instantiate(laser);
        shield = Instantiate(shield, transform, false);

        missile.SetActive(false);
        bullet1.SetActive(false);
        bullet2.SetActive(false);
        laser.SetActive(false);
        shield.SetActive(false);
    }

    public void OnPlayerDead()
    {
        _sprite.color = Color.clear;
        Invoke("Respawn", 1f);
    }

    private void Update()
    {
        if (_health.isDead) return;

        Attack();

        _animator.SetFloat("Vertical", _input.y);
    }

    private void Attack()
    {
        if (!_input.isAttack) return;
        if (!bullet1.activeSelf && !_laser)
        {
            bullet1.SetActive(true);
            bullet1.transform.position = transform.position;
            GameManager.Instance.PlaySFX("Shoot");
        }

        if (!missile.activeSelf && _missile)
        {
            missile.SetActive(true);
            missile.transform.position = transform.position;
        }

        if (!bullet2.activeSelf && _double)
        {
            bullet2.SetActive(true);
            bullet2.transform.position = transform.position;
        }

        if (!laser.activeSelf && _laser)
        {
            bullet2.SetActive(true);
            bullet2.transform.position = transform.position;
            GameManager.Instance.PlaySFX("Laser");
        }
    }

    private void FixedUpdate()
    {
        if (_health.isDead)
        {
            _move.Move(0, 0);
            return;
        }

        _move.Move(_input.x, _input.y);
    }

    public void Respawn()
    {
        _animator.SetBool("Dead", false);
        _health.Reset();
        transform.position = Vector3.left * 6.4f;
    }

    public void PowerUp(Power power)
    {
        switch (power)
        {
            case Power.None:
                break;
            case Power.Speed:
                if (_move.speed >= PlayerMove.MaxSpeed) return;
                _move.speed += 0.5f;
                break;
            case Power.Missile:
                _missile = true;
                break;
            case Power.Double:
                _double = true;
                _laser = false;
                break;
            case Power.Laser:
                _laser = true;
                _double = false;
                break;
            case Power.Option:
                Instantiate(option, transform.position, Quaternion.identity);
                break;
            case Power.Shield:
                shield.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(power), power, null);
        }
    }
}