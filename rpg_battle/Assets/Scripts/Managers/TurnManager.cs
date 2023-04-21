using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event Action OnDisableInputs;
    public event Action OnEnableInputs;

    [SerializeField] private Slime _slime;
    [SerializeField] private Druid _druid;

    public void OnEnable()
    {
        _druid.OnTurnEnd += SlimeTurn;
    }

    public void OnDisable()
    {
        _druid.OnTurnEnd -= SlimeTurn;
    }

    public void SlimeTurn()
    {
        _slime.Shoot(
            () =>
            {
                _druid.Damage(2); 
                EnableInputs();
            }
        );
        
    }

    public void OnAttackButtonClicked()
    {
        DisableInputs();
        _druid.Stomp(
            () => { _slime.Damage(2); }
        );
    }

    private void DisableInputs()
    {
        OnDisableInputs.Invoke();
    }

    private void EnableInputs()
    {
        OnEnableInputs?.Invoke();
    }
}