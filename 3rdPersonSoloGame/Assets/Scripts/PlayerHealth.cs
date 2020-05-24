using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    #region PUBLIC VARIABLES

    [Header("Health Variables")]
    public int maximumHealth;
    public int currentHealth;
    public Slider healthSlider;

    [Header("Damage Variables")]
    public Image damageImage;
    public AudioClip deathClip;

    #endregion

 //   Animator _anim;
 //   AudioSource _playerAudio;
    Player _player;

    [SerializeField]
    bool isDead;
    bool damaged;

    private void Awake()
    {
   //     _anim = GetComponent<Animator>();
   //    _playerAudio = GetComponent<AudioSource>();
        _player = GetComponent<Player>();
        currentHealth = maximumHealth;
    }

   public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

   //     _playerAudio.Play();

    }

    public void Death()
    {

        Debug.Log("Player Died");
        _player.enabled = false;
        isDead = true;

        /*   _anim.SetTrigger("Die");
           _playerAudio.clip = deathClip;
           _playerAudio.Play();*/        
    }

    public void LoadGameOver(string GameOver)
    {
        if (currentHealth <= 0 /*&& (isDead == false)*/)
        {
            SceneManager.LoadScene(GameOver);
        }
    }
}
