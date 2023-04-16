using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidHealth : Health
{
    [SerializeField]private DruidAnimationController _animationController;
    
    public override void Damage(int damage)
    {
        _animationController.GetHit();
        base.Damage(damage);
    }
}
