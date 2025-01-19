using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text _scoreboardText;

    private int _score = 0;

    public void IncreaseScore(int amount) {
        _score += amount;
        _scoreboardText.text = $"Score: {_score}";
    }
}   
