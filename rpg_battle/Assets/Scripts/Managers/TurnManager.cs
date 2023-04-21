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
    [SerializeField] private GameObject gui;

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

    public void Start()
    {
        StartCoroutine(EnableUIAfterSeconds(5.2f));
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

    private void ActivateUI()
    {
        _slime.EnableHealthDisplay();
        _druid.EnableHealthDisplay();
        gui.SetActive(true);
    }
    
    private IEnumerator EnableUIAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        ActivateUI();
    }
}