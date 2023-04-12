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
    public void OnAttackButtonClicked()
    {
        DisableInputs();
        _slime.Damage(2);
        StartCoroutine(WaitAndEnableInputs(2.0f));
    }

    private IEnumerator WaitAndEnableInputs(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        EnableInputs();
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
