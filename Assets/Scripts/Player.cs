using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMove), typeof(Health))]
public class Player : MonoBehaviour
{
    public GameObject missile;
    public GameObject option;
    public GameObject shield;
    public ProjectileData bullet;
    public ProjectileData laser;
    public GameObject projectile;

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

        _health.OnDead += () => { _animator.SetBool("Dead", true); };
    }

    public void OnPlayerDead()
    {
        _sprite.color = Color.clear;
        Invoke("Respawn", 1f);
    }

    private void Update()
    {
        if (_health.isDead) return;

        if (_input.isAttack && projectile && _double)
        {
            for (int i = 0; i < 2; i++)
            {
                // TODO - Fix double
                var temp = Instantiate(projectile, transform.position, Quaternion.identity);
                temp.GetComponent<Projectile>().data = _laser ? laser : bullet;
            }
        }
        else if (_input.isAttack && projectile)
        {
            var temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.GetComponent<Projectile>().data = _laser ? laser : bullet;
        }

        if (_input.isAttack && _missile)
        {
            
        }

        _animator.SetFloat("Vertical", _input.y);
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
                _move.speed++;
                break;
            case Power.Missile:
                _missile = true;
                break;
            case Power.Double:
                _double = true;
                break;
            case Power.Laser:
                _laser = true;
                break;
            case Power.Option:
                var temp = Instantiate(option, transform.position, Quaternion.identity);
                // TODO - Add option
                break;
            case Power.Shield:
                Instantiate(shield, transform);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(power), power, null);
        }
    }
}
