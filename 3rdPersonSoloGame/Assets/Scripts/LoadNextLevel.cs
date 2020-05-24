using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    private int nextSceneLoad;

    private void Start()
    {
       nextSceneLoad = (SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextSceneLoad);
    }
}
