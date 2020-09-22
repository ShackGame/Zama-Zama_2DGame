using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static float Score;
    public static float Health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public TMP_Text scoreTxt;

    private void Start()
    {
        Health = 5f;
    }
    private void Update()
    {
        scoreTxt.text = "Score: " + Score;

        if(Health > numberOfHearts)
        {
            Health = numberOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < Health)
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
