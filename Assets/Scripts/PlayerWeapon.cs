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
        AimLasers();
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

    private void MoveTargetPoint()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _targetDistance);
        _targetPoint.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void AimLasers()
    {
        foreach (GameObject laser in _lasers)
        {
            Vector3 fireDirection = _targetPoint.position - this.transform.position;
            Quaternion rotationTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationTarget;
        }
    }
}
