using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class QuitGame : MonoBehaviour
{

    public static QuitGame instance;

    public string nextSceneAddress;

    public Animator transition;

    public float transtionTime = 2f;

    public GameObject loadGameUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;           
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

    public IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transtionTime);

        Addressables.LoadSceneAsync(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
