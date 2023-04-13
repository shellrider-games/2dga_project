using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private float lerpSpeed = 10f;

    private Image _healthBar;
    private float _targetFill = 1f;

    private void Awake()
    {
        _healthBar = transform.Find("HealthBar").GetComponent<Image>();
        if (health is null) return;
        InitFill(health.Hitpoints / (float)health.MaxHitpoints);
        health.OnHealthUpdated += (hp, maxHp) => SetTargetFill(hp / (float)maxHp);
    }

    private void Update()
    {
        if (Math.Abs(_targetFill - _healthBar.fillAmount) > 0.001f)
        {
            _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _targetFill, Time.deltaTime * lerpSpeed);
        }
        else
        {
            _healthBar.fillAmount = _targetFill;
        }
    }

    private void InitFill(float fill)
    {
        _healthBar.fillAmount = fill;
        _targetFill = fill;
    }

    private void SetTargetFill(float fill)
    {
        Debug.Log("SetTargetFill");
        _targetFill = fill;
    }
}