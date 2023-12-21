using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject ending;

    public void OnRetry()
    {
        SceneManager.LoadScene("MainScene");
        ending.SetActive(false);
    }
}