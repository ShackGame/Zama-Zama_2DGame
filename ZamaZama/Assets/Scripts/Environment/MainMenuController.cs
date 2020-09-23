using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        Addressables.LoadSceneAsync("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
