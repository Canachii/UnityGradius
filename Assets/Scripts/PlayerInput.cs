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

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        isAttack = Input.GetKey(attack);

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