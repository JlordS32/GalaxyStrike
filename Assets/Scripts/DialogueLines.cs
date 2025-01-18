using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text _dialogueText;

    private int _currentLine = 0;

    public void NextDialogueLine()
    {   
        _currentLine++;
        _dialogueText.text = $"{timelineTextLines[_currentLine]}";
    }
}
