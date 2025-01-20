using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

    GameSceneManager _gameSceneManager; 

    private void Start() {
        _gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameSceneManager.ReloadLevel();
        Instantiate(_explosionPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
