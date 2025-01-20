using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private int _delayInSeconds = 2;

    public void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadLevel(currentSceneIndex));
    }

    IEnumerator LoadLevel(int levelIndex) {
        yield return new WaitForSeconds(_delayInSeconds);
        SceneManager.LoadScene(levelIndex);
    }
}
