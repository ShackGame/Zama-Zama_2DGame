﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;

public class RewardScript : MonoBehaviour
{
   
    public void OnUserEarnedReward(Reward reward)
   {
        GameManager.instance.Score += 500f;
   }
}
