using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel_1(){

        SceneManager.LoadScene("SampleScene");
    }

    public void LoadLevel_2(){

        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel_3(){

        SceneManager.LoadScene("Level3");
    }
}
