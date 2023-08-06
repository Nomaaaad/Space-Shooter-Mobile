using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera mainCamera;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemy;

    [SerializeField] private float enemySpawnTime;
    private float enemyTimer;
    void Start()
    {
        mainCamera = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    void Update()
    {
        EnemySpawn();
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForSeconds(.2f);

        maxLeft = mainCamera.ViewportToWorldPoint(new Vector2(.15f, 0)).x;
        maxRight = mainCamera.ViewportToWorldPoint(new Vector2(.85f, 0)).x;
        yPos = mainCamera.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }

    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }
}
