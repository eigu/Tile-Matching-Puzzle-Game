using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    private Camera m_mainCamera;

    [SerializeField]
    private float _aimAngleLimit;
    [SerializeField]
    private float _aimRotationSpeed;

    private void Start()
    {
        m_mainCamera = Camera.main;
    }

    private void Update()
    {
        float targetAngle = CalculateAimAngle();

        float clampedAngle = ClampAngle(targetAngle);

        RotateTowards(clampedAngle);
    }

    private float CalculateAimAngle()
    {
        Vector3 mousePosition = m_mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0f;

        Vector2 aimDirection = (mousePosition - transform.position).normalized;

        return Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
    }

    private float ClampAngle(float targetAngle)
    {
        float currentAngle = transform.eulerAngles.z;

        float angleDifference = Mathf.DeltaAngle(currentAngle, targetAngle);

        float rotationStep = _aimRotationSpeed * Time.deltaTime;

        float nextAngle = currentAngle + Mathf.Sign(angleDifference) * rotationStep;

        return Mathf.Clamp(Mathf.DeltaAngle(0, nextAngle), -_aimAngleLimit, _aimAngleLimit);
    }

    private void RotateTowards(float clampedAngle)
    {
        transform.rotation = Quaternion.Euler(0, 0, clampedAngle);
    }
}
