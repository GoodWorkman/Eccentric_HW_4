using UnityEngine;

public class GunActivator : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _fireRate = 10f;
    [SerializeField] private float _rayDistance = 50f;
    [SerializeField] private float _impactForce = 60f;

    [SerializeField] private Camera _playerCamera;
    [SerializeField] private ParticleSystem _muzzleFlashLeft;
    [SerializeField] private ParticleSystem _muzzleFlashRight;
    [SerializeField] private GameObject _impactEffect;
    

    private float _timeToFire = 0f;

   private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > _timeToFire)
            {
                _timeToFire = Time.time + 1f / _fireRate;
                Shoot();
            }

            //Shoot();
        }
    }

    private void Shoot()
    {
        _muzzleFlashLeft.Play();
        _muzzleFlashRight.Play();

        Ray ray = _playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        RaycastHit hit;

        IDamageable target = null;

        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            if (hit.collider.attachedRigidbody)
            {
                target = hit.collider.attachedRigidbody.GetComponent<IDamageable>();

                hit.collider.attachedRigidbody.AddForce(-hit.normal * _impactForce);
            }
            else
            {
                target = hit.collider.GetComponentInParent<IDamageable>();
            }

            if (target != null)
            {
                Debug.Log("name of RB holder: " + target);

                target.ApplyDamage(_damage);
            }

            GameObject impact = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }
    }
}