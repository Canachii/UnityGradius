using System;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 3f;
    private float _time = 0f;

    private void Start()
    {
        GameManager.Instance.PlayBGM("BGM01");
    }

    private void Update()
    {
        _time += Time.deltaTime;
        const float delTime = 60f;
        if (_time >= delTime)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    private void OnBecameVisible()
    {
        GameManager.Instance.PlayBGM("BGM02");
    }
}