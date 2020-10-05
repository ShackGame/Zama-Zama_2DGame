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

    AudioManager audioManager;

    [SerializeField]
    private string menuBtn;

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

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No AudioManager found");
        }
    }
    public void OnButtonStart()
    {
        audioManager.PlaySound(menuBtn);
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
        audioManager.PlaySound(menuBtn);
        Application.Quit();
    }

    public void MenuBtnSound()
    {
        audioManager.PlaySound(menuBtn);
    }
}
