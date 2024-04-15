using UnityEngine;
using UnityEngine.SceneManagement;

public class BigCore : Enemy
{
    public GameObject projectile;
    public GameObject core;

    private Vector2 _start;
    private Vector2 _end;
    private float _time;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Health.OnDead = () =>
        {
            core.SetActive(false);
            Animator.SetTrigger("Dead");
            GameManager.Instance.PlaySFX("BossDestroy");
        };

        _start = transform.position;
        _end = transform.position;

        projectile = Instantiate(projectile, transform.position, Quaternion.identity);
        projectile.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();
        Animator.SetInteger("HP", Health.health);
    }

    public override void OnEnemyDead()
    {
        SceneManager.LoadSceneAsync(0);
    }

    protected override void Move()
    {
        _time += Time.deltaTime;
        var t = _time / speed;
        transform.position = Vector2.Lerp(_start, _end, t);
        if (_time >= speed)
        {
            _start = transform.position;
            _end = new Vector2(transform.position.x,
                transform.position.y + GameManager.Instance.WherePlayerVertical(transform.position) * 3);
            _time = 0;

            projectile.SetActive(true);
            projectile.transform.position = transform.position;
        }
    }
}
