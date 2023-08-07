using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;

    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (EndGameManager.Instance.gameOver == true) return;

        timer += Time.deltaTime;
        if(timer >= possibleWinTime)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }
            EndGameManager.Instance.StartResolveSequence();
            gameObject.SetActive(false);
        }
    }
}
