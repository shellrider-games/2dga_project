using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public event Action OnDisableInputs;
    public event Action OnEnableInputs;

    [SerializeField] private AudioSource _battleMusic;
    [SerializeField] private AudioSource _victoryMusic;

    [SerializeField] private Slime _slime;
    [SerializeField] private Druid _druid;
    
    [SerializeField] private GameObject attackButton;
    [SerializeField] private GameObject victoryText;

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
        _slime.OnDeath += Victory;
    }

    public void Victory()
    {
        attackButton.SetActive(false);
        _druid.DisableHealthDisplay();
        StartCoroutine(ActivateVictoryTextAfterSeconds(1));
    }

    public IEnumerator ActivateVictoryTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _battleMusic.Stop();
        _victoryMusic.Play();
        victoryText.SetActive(true);
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
        attackButton.SetActive(true);
        _battleMusic.Play();
    }
    
    private IEnumerator EnableUIAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        ActivateUI();
    }
}