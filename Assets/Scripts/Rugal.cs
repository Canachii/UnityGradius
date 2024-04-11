using UnityEngine;

public class Rugal : Enemy
{
    private int _y;
    private Player _player;

    protected override void Start()
    {
        base.Start();
        _player = FindObjectOfType<Player>();
    }

    protected override void Update()
    {
        base.Update();

        const float y = 0.1f;

        if (transform.position.y + y < _player.transform.position.y)
        {
            _y = 1;
        }
        else if (transform.position.y - y > _player.transform.position.y)
        {
            _y = -1;
        }
        else _y = 0;

        Animator.SetFloat("Vertical", _y);
    }

    protected override void Move()
    {
        base.Move();
        transform.Translate(Vector3.up * speed * _y * Time.deltaTime);
    }
}