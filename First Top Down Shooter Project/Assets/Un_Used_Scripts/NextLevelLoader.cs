using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    private GameObject[] enemiesArray;
    private int nextLevel = 0;
    private float timer = 0;

    void Update(){

        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemiesArray.Length == 0){
            timer += Time.deltaTime;
            if(timer > 2){
                LoadNextLevel();
            }
        }
    }
    
    private void LoadNextLevel(){

        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel == 5){
            SceneManager.LoadScene("MainMenu");
        }

        SceneManager.LoadScene(nextLevel);
    }
}
