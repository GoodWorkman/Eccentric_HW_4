using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float Health = 100f;

    public void ApplyDamage(float damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
