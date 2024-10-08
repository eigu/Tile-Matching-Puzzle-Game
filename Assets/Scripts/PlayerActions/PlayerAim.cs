using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerAim : MonoBehaviour
{
    private Camera m_mainCamera;

    [SerializeField]
    private Transform _aimAxis;
    [SerializeField]
    private float _aimAngleLimit = 45f;
    [SerializeField]
    private float _aimRotationSpeed = 90f;
    [SerializeField]
    private float _angleTolerance = 0.1f;

    private void Start()
    {
        m_mainCamera = Camera.main;
    }

    private void Update()
    {
        float aimAngle = CalculateAimAngle();

        float clampedAimAngle = ClampAimAngle(aimAngle);

        RotateTowards(clampedAimAngle);
    }

    private float CalculateAimAngle()
    {
        Vector3 mousePosition = m_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f;

        Vector2 aimDirection = (mousePosition - _aimAxis.position).normalized;

        return Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }

    private float ClampAimAngle(float targetAngle)
    {
        float currentAngle = GetCurrentAngle();

        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        if (Mathf.Abs(angleDifference) <= _angleTolerance) return targetAngle;

        float rotationStep = _aimRotationSpeed * Time.deltaTime;

        float nextAngle = currentAngle + Mathf.Sign(angleDifference) * rotationStep;

        return Mathf.Clamp(Mathf.DeltaAngle(0, nextAngle), -_aimAngleLimit, _aimAngleLimit);
    }

    private void RotateTowards(float clampedAngle)
    {
        _aimAxis.rotation = Quaternion.Euler(0, 0, clampedAngle);
    }

    public float GetCurrentAngle()
    {
        return _aimAxis.eulerAngles.z;
    }

    public void Initialize(ObjectInstance instance)
    {
        instance.gameObject.transform.rotation = Quaternion.Euler(0, 0, GetCurrentAngle());
    }
}
