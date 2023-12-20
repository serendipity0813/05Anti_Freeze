using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject ending;

    public void OnRetry()
    {
        SceneManager.LoadScene("MainScene");
        ending.SetActive(false);
    }
}