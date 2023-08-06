using UnityEngine;

public class PanelContoller : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    void Start()
    {
        EndGameManager.Instance.RegisterPanelController(this);
    }

    public void ActivateWin()
    {
        canvasGroup.alpha = 1;
        winScreen.SetActive(true);
    }

    public void ActivateLose()
    {
        canvasGroup.alpha = 1;
        loseScreen.SetActive(true);
    }
}
