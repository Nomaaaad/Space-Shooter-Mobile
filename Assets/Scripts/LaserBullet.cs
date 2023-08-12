using UnityEngine;
using UnityEngine.Pool;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private Rigidbody2D rb;

    private ObjectPool<LaserBullet> referencePool;

    void Start()
    {
        rb.velocity = Vector2.up * speed;
    }
    private void OnEnable()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        if (gameObject.activeSelf)
            referencePool.Release(this);
    }
    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
            referencePool.Release(this);
    }

    public void SetPool(ObjectPool<LaserBullet> pool)
    {
        referencePool = pool;
    }
}
