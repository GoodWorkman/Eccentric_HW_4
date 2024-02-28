using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
   [SerializeField] private Transform _follower;
   [SerializeField] private float _torqueForwardValue = 5f;
   [SerializeField] private float _torqueAngleValue = 5f;
   
   private Rigidbody _rigidbody;

   private float _horizontal;
   private float _vertical;

   private void Start()
   {
      _rigidbody ??= GetComponent<Rigidbody>();
      _rigidbody.maxAngularVelocity = 50f;
   }

   private void FixedUpdate()
   {
      _horizontal = Input.GetAxis("Horizontal");
      _vertical = Input.GetAxis("Vertical");
      
      _rigidbody.AddTorque(_follower.right * (_vertical * _torqueForwardValue));
      _rigidbody.AddTorque(-_follower.forward * (_horizontal * _torqueAngleValue));
   }
}
