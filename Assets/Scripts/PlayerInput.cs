using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float x;
    [HideInInspector] public float y;
    [HideInInspector] public bool isAttack;

    public KeyCode attack = KeyCode.J;
    public KeyCode power = KeyCode.K;

    [Header("Cheat")] public bool cheat;
    public KeyCode cheatPower = KeyCode.Alpha0;

    private float _pressBuffer;
    private const float AttackRate = 0.5f;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(attack) && _pressBuffer >= AttackRate)
        {
            isAttack = true;
            _pressBuffer = 0;
        }
        else
        {
            isAttack = false;
            _pressBuffer += Time.deltaTime;
        }

        if (Input.GetKeyDown(power))
        {
            GameManager.Instance.SetPower();
        }
        
        // Cheat
        if (!cheat) return;
        if (Input.GetKeyDown(cheatPower))
        {
            GameManager.Instance.AddPower();
        }
    }
}