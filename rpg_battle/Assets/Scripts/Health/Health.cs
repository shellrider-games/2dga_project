using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int, int> OnHealthUpdated;
    public event Action OnDeath;

    [SerializeField] private int maxHitpoints = 10;
    [SerializeField] private int hitpoints = 10;

    public int MaxHitpoints
    {
        get => maxHitpoints;
        private set
        {
            maxHitpoints = value;
            OnHealthUpdated?.Invoke(hitpoints, maxHitpoints);
        }
    }

    public int Hitpoints
    {
        get => hitpoints;
        private set
        {
            hitpoints = value;
            OnHealthUpdated?.Invoke(hitpoints, maxHitpoints);
        }
    }

    public virtual void Damage(int damage)
    {
        Hitpoints = Math.Max(Hitpoints - damage, 0);
        if (Hitpoints <= 0) Die();
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(transform.gameObject);
    }
}