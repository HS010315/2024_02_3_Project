using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private void OnEnable()
    {
        EventSystem.OnScoreChanged += UpdateScore;          //µ°º¿¿Ã æ∆¥— ±∏µ∂
        EventSystem.OnGameOver += ShowGameOver;
    }
    private void OnDisable()
    {
        EventSystem.OnScoreChanged -= UpdateScore;          //ª¨º¿¿Ã æ∆¥— ±∏µ∂ «ÿ¡¶
        EventSystem.OnGameOver -= ShowGameOver;
    }

    void UpdateScore(int newScore)
    {
        Debug.Log($"Score updated: {newScore}");
    }
    void ShowGameOver()
    {
        Debug.Log("Game Over!");
    }
}
