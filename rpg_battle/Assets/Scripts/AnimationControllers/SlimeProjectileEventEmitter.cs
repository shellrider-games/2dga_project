using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectileEventEmitter : MonoBehaviour
{
    public event Action OnAnimationEnd;

    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }
}
