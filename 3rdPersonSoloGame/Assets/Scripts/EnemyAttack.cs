using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    #region PUBLIC VARIABLES
    [Header("Attack Variables")]
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    #endregion

    #region PRIVATE VARIABLES
    Animator _anim;
    GameObject _player;
    PlayerHealth _playerHealth;

    bool _playerInRange;
    float _timer;
    #endregion

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = _player.GetComponent<PlayerHealth>();

        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInRange = false;
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= timeBetweenAttacks && _playerInRange)
        {
            Attack();
        }
        if (_playerHealth.currentHealth <= 0)
        {
            _anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        _timer = 0f; 

        if(_playerHealth.currentHealth > 0)
        {
            _playerHealth.TakeDamage(attackDamage);
        }
    }

}
