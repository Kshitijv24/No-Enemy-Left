using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    public Button[] levelButtons;

    private int reachedLevel;

    void Start(){
        
        foreach(Button button in levelButtons){

            button.interactable = false;
        }

        reachedLevel = PlayerPrefs.GetInt("ReachedLevel", 1);

        for(int i = 0; i < reachedLevel; i++){

            levelButtons[i].interactable = true;
        }
    }


}
