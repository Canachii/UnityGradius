using System;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollTime = 120f;
    public string BGMName = "BGM01";
    public GameObject boss;
    
    private float _time = 0f;
    private Vector2 _start;
    private Vector2 _end;

    private void Start()
    {
        GameManager.Instance.PlayBGM(BGMName);
        _end = transform.position;
        transform.position = Vector3.right * 300;
        _start = transform.position;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        var t = _time / scrollTime;
        if (_time >= scrollTime)
        {
            Background.IsScroll = false;
            var enemy = FindObjectsOfType<Enemy>();
            foreach (var item in enemy)
            {
                Destroy(item.gameObject);
            }
            if (boss) Instantiate(boss, Vector2.right * 4f, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            transform.position = Vector2.Lerp(_start, _end, t);
        }
    }
}