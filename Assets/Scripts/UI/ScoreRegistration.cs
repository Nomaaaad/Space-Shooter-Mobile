using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    void Start()
    {
       TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        EndGameManager.Instance.RegisterScoreText(text);
        text.text = "Score: 0";
    }
}
