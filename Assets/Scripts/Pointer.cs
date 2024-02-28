using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinCounter _coinCounter;

    private Vector3 _target;

    private void Update()
    {
        _target = _coinCounter.GetTarget(transform.position);

        Vector3 directionToTarget = (_target - transform.position).normalized;

        directionToTarget.y = 0f;

        if (directionToTarget != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(directionToTarget);
        }
        
    }
}
