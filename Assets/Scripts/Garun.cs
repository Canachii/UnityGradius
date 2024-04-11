using UnityEngine;

public class Garun : Enemy
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
        _yPosition = y;
    }

    protected override void Move()
    {
        base.Move();
        transform.position = new Vector3(transform.position.x, _yPosition);
    }
}