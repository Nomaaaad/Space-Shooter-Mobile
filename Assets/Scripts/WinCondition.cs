using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;
    public bool canSpawnBoss = false;

    private float timer;

    void Update()
    {
        if (EndGameManager.Instance.gameOver == true) return;

        timer += Time.deltaTime;
        if (timer >= possibleWinTime)
        {
            if (!hasBoss)
            {
                EndGameManager.Instance.possibleWin = true;
                EndGameManager.Instance.StartResolveSequence();
            }
            else
            {
                canSpawnBoss = true;
            }

            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }

            gameObject.SetActive(false);
        }
    }
}
