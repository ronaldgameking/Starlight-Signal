using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void LoadSceneByName(string scenename)
    {
       SceneManager.LoadScene(scenename);
    }
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
