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

    private void Start()
    {
        GameManager.Health = 5f;
    }
    private void Update()
    {
        scoreTxt.text = "Score: " + GameManager.Score;

        if(GameManager.Health > numberOfHearts)
        {
            GameManager.Health = numberOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < GameManager.Health)
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
