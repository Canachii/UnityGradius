using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        _material.mainTextureOffset += Vector2.right * Time.deltaTime * speed;
        if (_material.mainTextureOffset.x >= 1)
        {
            _material.mainTextureOffset = Vector2.zero;
        }
    }
}