using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private int _healthPoints;
    [SerializeField] private int _scorePoints;

    Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        _healthPoints--;

        if (_healthPoints <= 0)
        {
            scoreboard.IncreaseScore(_scorePoints);
            Instantiate(_explosionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
