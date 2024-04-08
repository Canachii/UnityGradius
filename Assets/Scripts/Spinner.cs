using UnityEngine;

public class Spinner : Enemy
{
    [Header("Spec")]
    public float speed = 5f;
    protected override void Move()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}