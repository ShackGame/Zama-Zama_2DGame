using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class QuitGame : MonoBehaviour
{
    public string nextSceneAddress;

    public Animator transition;

    public float transtionTime = 2f;

    public GameObject loadGameUI;

    private void Start()
    {
        loadGameUI.SetActive(false);
    }
    public void OnButtonStart()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transtionTime);

        Addressables.LoadSceneAsync(nextSceneAddress);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
