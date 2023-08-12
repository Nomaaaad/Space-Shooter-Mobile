using UnityEngine;
using UnityEngine.Pool;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private LaserBullet laserBullet;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float shootInterval;

    private float intervalReset;

    private ObjectPool<LaserBullet> laserBulletPool;

    private void Awake()
    {
        laserBulletPool = new ObjectPool<LaserBullet>(CreatePoolObj, OnTakeBulletFromPool, OnReturnBulletFromPool, OnDestroyPoolObj, true, 10, 30);
    }

    void Start()
    {
        intervalReset = shootInterval;
    }

    void Update()
    {
        shootInterval -= Time.deltaTime;

        if (shootInterval <= 0)
        {
            Shoot();
            shootInterval = intervalReset;
        }
    }

    private LaserBullet CreatePoolObj()
    {
        LaserBullet bullet = Instantiate(laserBullet, transform.position, transform.rotation);
        bullet.SetPool(laserBulletPool);
        return bullet;
    }

    private void OnTakeBulletFromPool(LaserBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReturnBulletFromPool(LaserBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObj(LaserBullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void Shoot()
    {
        audioSource.Play();
        laserBulletPool.Get().transform.position = shootPosition.position;
    }
}
