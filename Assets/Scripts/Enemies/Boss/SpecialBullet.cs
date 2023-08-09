using System.Collections;
using UnityEngine;

public class SpecialBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject miniBullet;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
        StartCoroutine(Explode());
    }

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodeTime);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(miniBullet, spawnPoints[i].position, spawnPoints[i].rotation);
        }
        Destroy(gameObject);
    }
}
