using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    private string APP_ID = "ca-app-pub-8500404916786212~3971439025";
    private BannerView bannerAD;
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardVideoAd;
    
    void Start()
    {
        //this is when you publish app
        // MobileAds.Initialize(APP_ID);
        RequestBanner();
        RequestInterstitial();
        RequestVideoAD();

    }

    void RequestBanner()
    {
        string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //FOR REAL APP
       // AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR Testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        bannerAD.LoadAd(adRequest);

    }

    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitial_ID);

        //FOR REAL APP
        // AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR Testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        interstitialAd.LoadAd(adRequest);

    }

    void RequestVideoAD()
    {
        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardVideoAd = RewardBasedVideoAd.Instance;

        //FOR REAL APP
        // AdRequest adRequest = new AdRequest.Builder().Build();

        //FOR Testing
        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("33BE2250B43518CCDA7DE426D04EE231").Build();

        rewardVideoAd.LoadAd(adRequest, video_ID);

    }

    public void Display_Banner()
    {
        bannerAD.Show();

    }

    public void Display_IntertitialAD()
    {
        if (interstitialAd.IsLoaded) {
            interstitialAd.Show();
        }

    }

    public void Display_Reward_Video()
    {
        if (rewardVideoAd.IsLoaded)
        {
            rewardVideoAd.Show();
        }

    }

    //Handle Events

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // ad is loaded show it
        Display_Banner();

    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // ad failed to load, load again
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscribe)
    {
        if (subscribe) { 
        // Called when an ad request has successfully loaded.
        bannerAD.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerAD.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerAD.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        } else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }

    }

    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }
}
