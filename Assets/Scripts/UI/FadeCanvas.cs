using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas Instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        loadingScreen.SetActive(false);

        fadeStarted = false;
        while (canvasGroup.alpha > 0)
        {
            if (fadeStarted) yield break;

            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator FadeOutName(string levelName)
    {
        if (fadeStarted) yield break;

        fadeStarted = true;
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName);
        asyncOperation.allowSceneActivation = false;

        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while (asyncOperation.isDone == false)
        {
            loadingBar.fillAmount = asyncOperation.progress / .9f;

            if (asyncOperation.progress == .9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
        StartCoroutine(FadeIn());
    }

     IEnumerator FadeOutInt(int levelIndex)
    {
        if (fadeStarted) yield break;

        fadeStarted = true;

        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);
        }

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelIndex);
        asyncOperation.allowSceneActivation = false;

        loadingScreen.SetActive(true);
        loadingBar.fillAmount = 0;

        while (asyncOperation.isDone == false)
        {
            loadingBar.fillAmount = asyncOperation.progress / .9f;
            if (asyncOperation.progress == .9f)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        StartCoroutine(FadeIn());
    }

    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutName(levelName));
    }

    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }
}
