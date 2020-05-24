using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [Header("Animator")]
    public Animator anim;

    [Header("Weapon")]
    public GameObject weapon;
    public GameObject attacker;
    public Transform player;

    [Header("Attack Variables")]
    public Transform attackPoint;
    public LayerMask whatAreEnemies;
    public int attackDamage;
  //  public float knockbackStrength;

    Vector3 _boxSize;

    void Start ()
    {
       
    }
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        } else {
        }
    }

    void Attack()
    {
        //KnockBack Force
        

        anim.SetTrigger("Attack");

        //Detect enemies in range of the attack
        Collider[] hitEnemies = Physics.OverlapBox(attackPoint.position, weapon.transform.localScale / 3,
                                                   Quaternion.identity, whatAreEnemies);
        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
           Rigidbody enemyRB = enemy.GetComponent<Rigidbody>();
           
/*
            if (enemyRB != null)
              {
                  Vector3 direction = player.forward;
                  direction.y = 0;

                  enemyRB.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
                Debug.Log("KnockBack");
              }*/
            Debug.Log("We Hit" + enemy.name);
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireCube(attackPoint.position, weapon.transform.localScale / 3);
    }
}
