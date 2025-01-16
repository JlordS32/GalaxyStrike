using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Collision with {other.name}");
    }
}
