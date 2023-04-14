using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event Action OnDisableInputs;
    public event Action OnEnableInputs;

    private bool _ignoreInput = false;

    [SerializeField] private Health _slime;
    [SerializeField] private Health _druid;
    [SerializeField] private DruidAnimationController _druidAnimationController;
    [SerializeField] private SlimeProjectileEffectAnimation _slimeProjectileEffect;

    public void OnAttackButtonClicked()
    {
        DisableInputs();
        _druidAnimationController.Stomp(
            () =>
            {
                _slime.Damage(2);
                _slimeProjectileEffect.Shoot(() => _druid.Damage(2));
                EnableInputs();
            }
        );
    }

    private void DisableInputs()
    {
        _ignoreInput = true;
        OnDisableInputs.Invoke();
    }

    private void EnableInputs()
    {
        _ignoreInput = false;
        OnEnableInputs?.Invoke();
    }
}