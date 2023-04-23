using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public event Action OnDeath;
    
    [SerializeField] private SlimeAnimationController slimeAnimationController;
    [SerializeField] private SlimeHealth slimeHealth;
    [SerializeField] private GameObject healthDisplay;

    public void Shoot(SlimeAnimationController.ShotHitCallback callback) => slimeAnimationController.Shoot(callback);
    public void Damage(int damage) => slimeHealth.Damage(damage);

    public void Start()
    {
        slimeHealth.OnDeath += () => { OnDeath?.Invoke(); };
    }

    public void EnableHealthDisplay()
    {
        healthDisplay.SetActive(true);
    }
}
