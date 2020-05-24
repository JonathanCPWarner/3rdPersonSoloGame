using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    Transform _player;
    PlayerHealth _playerHealth;
   // EnemyHealth _enemyHealth;
    NavMeshAgent _nav;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;


        _nav = GetComponent<NavMeshAgent>();
        
    }

	
	void Update ()
    {
        _nav.SetDestination(_player.position);
	}
}
