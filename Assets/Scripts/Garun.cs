using UnityEngine;

public class Garun : Enemy
{
    public float yRange = 2f;
    private float _tick;
    private Vector2 _pos;
    private float _y;

    protected override void Start()
    {
        base.Start();
        _pos = transform.position;
    }

    protected override void Update()
    {
        base.Update();

        _tick += Time.deltaTime;
        _y = _pos.y;
        _y += Mathf.Sin(_tick * speed) * yRange;
    }

    protected override void Move()
    {
        base.Move();
        transform.position = new Vector3(transform.position.x, _y);
    }
}