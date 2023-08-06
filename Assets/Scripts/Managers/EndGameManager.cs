using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager Instance;

    public bool gameOver;

    private PanelContoller panelContoller;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void WinGame()
    {
        panelContoller.ActivateWin();
    }

    public void LoseGame()
    {
        panelContoller.ActivateLose();
    }

    public void ResolveGame()
    {
        if (gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void RegisterPanelController(PanelContoller pC)
    {
        panelContoller = pC;
    }

    public void StartResolveSequence()
    {
        StopCoroutine(ResolveSequence());
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }
}
