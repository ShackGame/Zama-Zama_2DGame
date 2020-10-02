using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Respawner respawn;
    public static bool isDead = false;
    public GameObject gameOverUI;

    public Animator transition;
    public float transtionTime = 2f;

    private float reviveCost = 150f;
    private float waitPeriod = 2f;

    InterstitialAdGameObject interstitialAd;


    public GameObject
        health,
        health1,
        health2,
        health3,
        health4,
        scoreTxt,
        leftBtn,
        rightBtn,
        jumpBtn,
        melee1,
        getFreeCoinsBtn,
        pauseBtn,
        noCoins,
        coinIcon;

    private void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("PS").GetComponent<Respawner>();
        gameOverUI.SetActive(false);
        noCoins.SetActive(false);

        interstitialAd = MobileAds.Instance
            .GetAd<InterstitialAdGameObject>("Interstitial Ad");

        MobileAds.Initialize((initStatus) => {
            Debug.Log("Initialized MobileAds");
        });

        getFreeCoinsBtn.SetActive(false);
    }

    private void Update()
    {
        if (isDead)
        {
            isDead = false;
                 
            StartCoroutine(DeathWaitPeriod());
        }
    }
    IEnumerator DeathWaitPeriod()
    {
        yield return new WaitForSeconds(2f);

        //Show Ad
        GetCoins();

            gameOverUI.SetActive(true);
            health.SetActive(false);
            health1.SetActive(false);
            health2.SetActive(false);
            health3.SetActive(false);
            health4.SetActive(false);
            leftBtn.SetActive(false);
            rightBtn.SetActive(false);
            pauseBtn.SetActive(false);
            jumpBtn.SetActive(false);
            melee1.SetActive(false);
            coinIcon.SetActive(false);
            scoreTxt.SetActive(false);
       
    }

    public void Revive()
    {
        if(GameManager.instance.Score - reviveCost >= 0)
        {
            GameManager.instance.Score -= reviveCost;
            respawn.Respawn();
            gameOverUI.SetActive(false);
            health.SetActive(true);
            health1.SetActive(true);
            health2.SetActive(true);
            health3.SetActive(true);
            health4.SetActive(true);
            leftBtn.SetActive(true);
            rightBtn.SetActive(true);
            pauseBtn.SetActive(true);
            jumpBtn.SetActive(true);
            melee1.SetActive(true);
            //melee2.SetActive(true);
            scoreTxt.SetActive(true);
        }
        else
        {
            noCoins.SetActive(true);
            StartCoroutine(FadeNoCoins());
        }
        
    }

    public void Restart()
    {
        Addressables.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    IEnumerator FadeNoCoins()
    {
        yield return new WaitForSeconds(waitPeriod);
        noCoins.SetActive(false);
    }

    public void LoadMenu()
    {
        StartCoroutine(QuitGame.instance.LoadLevel("Start"));
    }

    public void GetCoins()
    {
        interstitialAd.ShowIfLoaded();
    }

   
}
