using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private SlimeAnimationController slimeAnimationController;
    [SerializeField] private SlimeHealth slimeHealth;

    public void Shoot(SlimeAnimationController.ShotHitCallback callback) => slimeAnimationController.Shoot(callback);
    public void Damage(int damage) => slimeHealth.Damage(damage);
}
