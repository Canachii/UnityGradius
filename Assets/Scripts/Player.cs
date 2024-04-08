using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMove), typeof(Health))]
public class Player : MonoBehaviour
{
    public ProjectileData[] projectileData;
    public GameObject projectile;
    
    private PlayerInput _input;
    private PlayerMove _move;
    private Health _health;
    private Animator _animator;
    private int _power;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _move = GetComponent<PlayerMove>();
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();

        _health.OnDead += () => { _animator.SetBool("Dead", true); };
    }

    public void OnPlayerDead()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_health.isDead) return;

        _move.Move(_input.x, _input.y);

        if (_input.isAttack && projectile)
        {
            var temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.GetComponent<Projectile>().data = projectileData[Mathf.Clamp(_power, 0, projectileData.Length - 1)];
        }

        _animator.SetFloat("Vertical", _input.y);
    }
}