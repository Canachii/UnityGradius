using UnityEngine;

[CreateAssetMenu(fileName = "Default Projectile", menuName = "My Object/Projectile", order = 0)]
public class ProjectileData : ScriptableObject
{
    public Sprite sprite;
    public int damage = 1;
    public float speed = 10f;
    public string colliderTag = "Enemy";
    public Vector2 dir = Vector2.right;
    public bool penetrate;
}