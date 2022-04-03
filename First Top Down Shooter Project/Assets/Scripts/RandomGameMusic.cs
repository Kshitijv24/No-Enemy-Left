using UnityEngine;

public class RandomGameMusic : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
