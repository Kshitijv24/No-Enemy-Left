using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject youWinPannel;

    private void Start()
    {
        youWinPannel.GetComponent<Animator>().Play("You_Win");
    }

    public void YouWin()
    {
        youWinPannel.SetActive(true);
    }
}
