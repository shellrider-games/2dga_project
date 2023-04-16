using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineEffectAnimation : MonoBehaviour
{
    public event Action OnEnemyHit;
    public event Action OnAnimationOver;
    
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Trigger()
    {
        if (_animator is null) return;
        _animator.SetTrigger("VinesGo");
    }

    public void EnemyHit()
    {
        OnEnemyHit?.Invoke();
    }

    public void AnimationOver()
    {
        OnAnimationOver?.Invoke();
    }
}
