using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Image _healthBar;

    public float _maxHealth = 100, _currentHealth, _currentHealthPct ;

    public void Start()
    {
        _currentHealth = _maxHealth;
        _currentHealthPct = 1f;
    }

    public void ModifyHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealthPct = _currentHealth / _maxHealth;
        _healthBar.fillAmount = _currentHealthPct;
    }
}
