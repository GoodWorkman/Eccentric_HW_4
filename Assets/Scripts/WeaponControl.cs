using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _maxAngle = 25f;

    private float _currentAngle;
    private Quaternion _initialCameraRotation;

    private void Start()
    {
        _initialCameraRotation = _playerCamera.transform.localRotation;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1)) 
        {
            ActivateAiming();
        }
        else
        {
            DeactivateAiming();
        }
    }
    
    private void ActivateAiming()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _rotationSpeed;
        _currentAngle = Mathf.Clamp(_currentAngle - mouseY, -_maxAngle, _maxAngle);

        SetRotation(_currentAngle);
    }

    private void DeactivateAiming()
    {
        _playerCamera.transform.localRotation = Quaternion.Lerp(_playerCamera.transform.localRotation,
            _initialCameraRotation, Time.deltaTime * _rotationSpeed);
    }

    private void SetRotation(float rotAngle)
    {
        // пушки
        transform.localEulerAngles = new Vector3(rotAngle, 0f, 0f);
        //камера
        _playerCamera.transform.localEulerAngles = new Vector3(rotAngle, 0f, 0f);
    }
}