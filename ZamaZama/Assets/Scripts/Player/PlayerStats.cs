using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int numberOfHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TMP_Text scoreTxt;
    public GameObject coin;

    private void Start()
    {
        GameManager.instance.Health = 5f;
        
    }
    private void Update()
    {
        scoreTxt.text = " " + GameManager.instance.Score;
        

        if(GameManager.instance.Health > numberOfHearts)
        {
            GameManager.instance.Health = numberOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < GameManager.instance.Health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
