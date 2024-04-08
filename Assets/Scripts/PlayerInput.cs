using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [HideInInspector] public bool isAttack;

    public KeyCode attack = KeyCode.J;

    private float _pressTime;
    private const float AttackRate = 0.1f;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(attack))
        {
            if (_pressTime == 0)
            {
                isAttack = true;
            }

            if (_pressTime > 0)
            {
                isAttack = false;
                if (_pressTime >= AttackRate)
                {
                    _pressTime = 0;
                }
            }

            _pressTime += Time.deltaTime;
        }
        else
        {
            _pressTime = 0;
        }
    }
}