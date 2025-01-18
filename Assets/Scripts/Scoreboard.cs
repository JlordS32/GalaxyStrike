using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;

    private int _score = 0;

    public void IncreaseScore(int amount) {
        _score += amount;
        scoreboardText.text = $"Score: {_score}";
    }
}   
