using GoogleMobileAds.Api;
using GoogleMobileAds.Placement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admob : MonoBehaviour
{
    private void Start()
    {
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>{ });

        
    }
}
