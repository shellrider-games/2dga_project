using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeProjectileEffectAnimation : MonoBehaviour
{
    public delegate void OnShotEnd();

    private OnShotEnd _callback = null;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private SlimeProjectileEventEmitter _projectileEventEmitter;


    private void DeactivateEffect()
    {
        if(_callback is not null) { _callback(); }
        _callback = null;
        if(_projectileEventEmitter is null) return;
        _projectileEventEmitter.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        if (_projectileEventEmitter is not null) _projectileEventEmitter.OnAnimationEnd += DeactivateEffect;
    }

    private void OnDisable()
    {
        if (_projectileEventEmitter is not null) _projectileEventEmitter.OnAnimationEnd -= DeactivateEffect;
    }

    public void Shoot(OnShotEnd callback)
    {
        _audio.Play();
        _callback = callback;
        _projectileEventEmitter.gameObject.SetActive(true);
    }
}
