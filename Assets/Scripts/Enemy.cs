using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed; 
    
    public float health = 100;
    public int worth = 2;


    public GameObject deathEffect;

    private void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
        
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    void Die()
    {
        GameObject Effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        PlayerStats.money += worth;
        Destroy(Effect, 5f);
        Destroy(gameObject);
    }

    
    
    
}
