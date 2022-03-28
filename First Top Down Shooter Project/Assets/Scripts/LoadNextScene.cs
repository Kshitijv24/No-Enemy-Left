using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public void PlayButton(){
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitButton(){
        Application.Quit();
    }
}
