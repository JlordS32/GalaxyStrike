using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_explosionPrefab, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
