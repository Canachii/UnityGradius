using UnityEngine;

public class Rugal : Enemy
{
    public float dashSpeed = 2f;
    
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
        _y = GameManager.Instance.WherePlayerVertical(transform.position);
        Animator.SetFloat("Vertical", _y);
    }

    protected override void Move()
    {
        transform.Translate(new Vector3(-speed - (_y == 0 ? dashSpeed : 0f), 1f * _y) * Time.deltaTime);
    }
}