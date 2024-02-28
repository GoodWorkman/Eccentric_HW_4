using System;
using UnityEngine;

public class Coin : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isActiveBeforeCollision = true;
    private float _health = 30f;

    public Action<Coin> OnCoinCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActiveBeforeCollision) return;

        _isActiveBeforeCollision = false;

        if (other.attachedRigidbody)

        {
            PlayerMove playerMove = other.attachedRigidbody.GetComponent<PlayerMove>();

            if (playerMove != null)
            {
                DestroyObject();
            }
        }
    }

    public void ApplyDamage(float damageValue)
    {
        Debug.Log("remaining health: " + _health);
        
        _health -= damageValue;

        if (_health <= 0)
        {
            _health = 0;
            
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        OnCoinCollected?.Invoke(this);

        _audioSource.Play();

        Destroy(gameObject, _audioSource.clip.length);
    }
}