using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] _lasers;
    [SerializeField] RectTransform _crosshair;
    [SerializeField] Transform _targetPoint;
    [SerializeField] float _targetDistance = 100f;

    private bool _isFiring;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrossHair();
        MoveTargetPoint();
    }

    public void OnFire(InputValue value)
    {
        _isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        foreach (var weapon in _lasers)
        {
            ParticleSystem.EmissionModule emissionModule = weapon.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = _isFiring;
        }
    }

    private void MoveCrossHair()
    {
        _crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint() {
        Vector3 targetPosition = new(Input.mousePosition.x, Input.mousePosition.y, _targetDistance);
        _targetPoint.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }
}
