using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Speed")]
    [SerializeField] private float _speed = 1f;

    [Header ("Camera Range")]
    [SerializeField] private float _xClampRange = 10f;
    [SerializeField] private float _yClampRange = 10f;

    [Header ("Rotation")]
    [SerializeField] private float _controlRollFactor = -20f;
    [SerializeField] private float _controlPitchFactor = -18f;
    [SerializeField] private float _rotationSpeed = 10f;

    // Variables
    private Vector2 _movement;

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = _movement.x * _speed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXpos, -_xClampRange, _xClampRange);

        float yOffset = _movement.y * _speed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYpos, -_yClampRange, _yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0);
    }

    private void ProcessRotation()
    {
        float pitch = -_controlPitchFactor * _movement.y;
        float roll = -_controlRollFactor * _movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, roll, _movement.x * _controlRollFactor);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
