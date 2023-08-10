using UnityEngine;

public class PanelContoller : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject adLoseScreen;

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

    public void ActivateAdLose()
    {
        canvasGroup.alpha = 1;
        adLoseScreen.SetActive(true);
    }

    public void DeactivateAdLose()
    {
        canvasGroup.alpha = 0;
        adLoseScreen.SetActive(false);
    }
}
