using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : MonoBehaviour
{
    public event Action OnTurnEnd;
    
    [SerializeField] private DruidAnimationController druidAnimationController;
    [SerializeField] private DruidHealth druidHealth;
    [SerializeField] private GameObject healthDisplay;

    public void Start()
    {
        druidAnimationController.OnTurnEnd += () => { OnTurnEnd?.Invoke(); };
    }

    public void Stomp(DruidAnimationController.StompCallback callback) => druidAnimationController.Stomp(callback);

    public void Damage(int damage) => druidHealth.Damage(damage);
    
    public void EnableHealthDisplay()
    {
        healthDisplay.SetActive(true);
    }

}
