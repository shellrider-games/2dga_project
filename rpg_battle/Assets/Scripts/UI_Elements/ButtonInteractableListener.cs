using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableListener : MonoBehaviour
{
    [SerializeField] private TurnManager _turnManager;
    private Button _button;
    private void Awake()
    {
        _button = transform.GetComponent<Button>();
        if(_turnManager is null) return;
        _turnManager.OnDisableInputs += () => _button.interactable = false ;
        _turnManager.OnEnableInputs += () => _button.interactable = true ;
    }
}
