using UnityEngine;

public class PurpleEnemy : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform leftCanon;
    [SerializeField] private Transform rightCanon;

    [SerializeField] private float speed;
    [SerializeField] private float shootInterval;
    private float shootTimer = 0;

    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Instantiate(bullet, leftCanon.position, Quaternion.identity);
            Instantiate(bullet, rightCanon.position, Quaternion.identity);

            shootTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void HurtSequence()
    {
        animator.SetTrigger("isDamaged");
    }

    public override void DeathSequence()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
