using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;
    [SerializeField] private float _lerpRate = 60f;

    private void LateUpdate()
    {
        if (_player.velocity.magnitude < 0.1f) return;
        
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, _lerpRate * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(_player.velocity);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,
            _player.velocity.magnitude * Time.fixedDeltaTime);
    }
}