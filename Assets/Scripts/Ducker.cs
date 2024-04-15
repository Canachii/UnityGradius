using UnityEngine;

public class Ducker : Enemy
{
    public GameObject projectile;
    private bool isMoving;
    private bool isShoot;
    private float _time;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
    }

    protected override void Move()
    {
        base.Move();
        if (_time <= 2)
        {
            isMoving = true;
            transform.Translate(Vector2.right * speed * 3 * Time.deltaTime);
        }
        else if (_time <= 3)
        {
            isMoving = false;
        }
        else if (_time <= 4 && !isShoot)
        {
            isShoot = true;
            var temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.GetComponent<Projectile>().direction = GameManager.Instance.AimPlayer(transform.position);
            Destroy(temp, 3f);
        }

        if (_time >= 6)
        {
            _time = 0;
            isShoot = false;
        }

        Animator.SetBool("Aim", !isMoving);
        var face = isMoving ? 1 : -1;
        transform.localScale = transform.position.y > 0 ? new Vector2(face, -1) : new Vector2(face, 1);
    }
}
