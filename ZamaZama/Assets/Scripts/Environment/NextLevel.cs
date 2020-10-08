using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class NextLevel : MonoBehaviour
{
    public static NextLevel instance;

    public string nextSceneAddress;

    public Animator transition;

    public float transtionTime = 2f;

    InterstitialAdGameObject interstitialAd;

    private void Start()
    {

        interstitialAd = MobileAds.Instance
          .GetAd<InterstitialAdGameObject>("Interstitial Ad");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadLevel());
    }

    public void OnButtonStart()
    {
        StartCoroutine(LoadLevel());
    }
    
    public void OnButtonMenu()
    {
        GameManager.instance.Save();
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transtionTime);

        interstitialAd.ShowIfLoaded();
        Addressables.LoadSceneAsync(nextSceneAddress);
    }

   
}
