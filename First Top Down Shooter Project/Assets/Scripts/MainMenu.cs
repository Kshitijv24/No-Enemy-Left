using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void LevelScreen(){

        SceneManager.LoadScene("LevelSelector");
    }

    public void Exit(){

        Application.Quit();
    }
}
