using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public float startTime = 1f;
    private float _time;
    private Vector2 _startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.right * 20;
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        var t = _time / startTime;

        if (_time >= startTime && Input.GetKeyDown(KeyCode.J))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        transform.position = Vector2.Lerp(_startPosition, Vector2.zero, t);
    }
}
