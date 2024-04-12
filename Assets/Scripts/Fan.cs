using System.Collections;
using UnityEngine;

public class Fan : Enemy
{
    public float changeTime = 2f;

    private Vector2 _currentDir = Vector2.left;

    protected override void Start()
    {
        base.Start();
        StartCoroutine("ChangeDirection");
        Health.OnDead += () =>
        {
            StopCoroutine("ChangeDirection");
            _currentDir = Vector2.zero;
        };
    }

    private IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(changeTime);
        _currentDir = GameManager.Instance.WherePlayerVertical(transform.position) > 0 ? Vector2.one : new Vector2(1, -1);
        while (GameManager.Instance.WherePlayerVertical(transform.position) != 0)
        {
            yield return null;
        }
        _currentDir = Vector2.right;
    }

    protected override void Move()
    {
        transform.Translate(_currentDir.normalized * speed * Time.deltaTime);
    }
}