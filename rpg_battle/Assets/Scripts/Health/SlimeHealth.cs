using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : Health
{
    [SerializeField] private SlimeAnimationController _animationController;
    public override void Damage(int damage)
    {
        _animationController.GetHit();
        base.Damage(damage);
    }
}
