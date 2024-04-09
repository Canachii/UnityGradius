using UnityEngine;

public class Rugal : Enemy
{
    public float yRange = 2f;
    private float _tick;
    private float _yPosition;

    protected override void Start()
    {
        base.Start();
        _yPosition = transform.position.y;
    }

    protected override void Update()
    {
        base.Update();
        
        _tick += Time.deltaTime;
        var y = Mathf.Sin(_tick * speed) * yRange;
        Animator.SetFloat("Vertical", y - _yPosition);
        _yPosition = y;
    }

    protected override void Move()
    {
        base.Move();
        transform.position = new Vector3(transform.position.x, _yPosition);
    }
}