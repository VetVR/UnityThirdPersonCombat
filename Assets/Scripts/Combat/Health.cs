using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1000;
    private int health;
    private bool isInvulnerable;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public bool IsDead => health == 0;
    
    
    private void Start()
    {
        health = maxHealth;
        
    }

    public void DealDamage(int damage)
    {

        if (isInvulnerable)
        {
            return;
        }  
        
        if (health == 0) { return; }

        health = Mathf.Max(health - damage, 0);
        
        OnTakeDamage?.Invoke();
        
        Debug.Log(health);
        
        if (health == 0)
        {
            Debug.Log("Target is DEAD!");
            OnDie?.Invoke();
        }


        
        
    }

    public void SetInvulnerable(bool isInvulnerable)
    {
        this.isInvulnerable = isInvulnerable;
    }



}
