using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int maximumHealth = 100;
    public int currentHealth;
    
	void Start ()
    {
        currentHealth = maximumHealth;
	}
	
	public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
		
	}
    void Die()
    {
        Debug.Log("Enemy Died");

        GameObject.Destroy(this.gameObject, 0);
    }
}
