using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRadius : MonoBehaviour {

    #region     PUBLIC VARIABLES
    [Header("Blockades")]
    public GameObject blockade1;
    public GameObject blockade2;

    [Header("Timer")]
    public GameObject timerDisplay;
    public bool timerFinished = false;

    [Header("Other")]
    public GameObject enemy;
    public Transform spawnPoint;
    public GameObject objectiveDisplay;
    #endregion

    #region PRIVATE VARIABLES
    int maxEnemy = 5;
    int enemyCount = 0;

    //EnemyManager eM = EnemyManager();
    // EnemyHealth eH = EnemyHealth();

    #endregion



    public CountdownTimer cT;

    public void Awake()
    {
        cT = FindObjectOfType<CountdownTimer>();
        if (cT == null)
        {
            Debug.Log("I hate my life");
        }
    }
    private void Update()
    {

        if (cT.currentTime < 0)
        {
            Debug.Log("EnemyDead");
            timerFinished = true;

        }

        if (timerFinished == true)
        {
            Continue();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        blockade1.SetActive(true);
        blockade2.SetActive(true);
        timerDisplay.SetActive(true);
        objectiveDisplay.SetActive(true);
        cT.currentTime = 180f;

        Destroy(objectiveDisplay, 3);

        if (enemyCount >= maxEnemy)
        {
            return;
        }
     //   eM.Spawn();

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemyCount++;


    }

    void Continue()
    {
        blockade1.SetActive(false);
        blockade2.SetActive(false);

       timerDisplay.SetActive(false);

        this.gameObject.SetActive(false);

    }

}
