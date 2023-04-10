using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<int, int> OnHealthUpdated;

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
}