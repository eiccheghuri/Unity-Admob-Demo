using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AddManager : MonoBehaviour
{
    [SerializeField]
    private string _appId;
    
    private BannerView _bannerAd;
    private InterstitialAd _interstitialAd;
    private RewardBasedVideoAd _rewardVideoAd;


    public void Start()
    {
        RequestBanner();
        RequestInterestitial();
        RequestVideo();

    }



    public void RequestBanner()
    {
        string _bannerId = "ca-app-pub-3940256099942544/6300978111";
        _bannerAd = new BannerView(_bannerId,AdSize.SmartBanner,AdPosition.Top);

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        _bannerAd.LoadAd(adRequest);

    }
    public void RequestInterestitial()
    {
        string _interestitialId = "ca-app-pub-3940256099942544/1033173712";
        _interstitialAd = new InterstitialAd(_interestitialId);

        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
        _interstitialAd.LoadAd(adRequest);

    }


    public void RequestVideo()
    {

        string _videoId = "ca-app-pub-3940256099942544/5224354917";
        _rewardVideoAd = RewardBasedVideoAd.Instance;


        AdRequest adRequest = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        _rewardVideoAd.LoadAd(adRequest,_videoId);

    }



    public void Display_Banner()
    {
        _bannerAd.Show();
    }

    public void Display_Intersitial()
    {

        if(_interstitialAd.IsLoaded())
        {
            _interstitialAd.Show();
        }
        
    }

    public void Display_Video()
    {

        if(_rewardVideoAd.IsLoaded())
        {
            _rewardVideoAd.Show();
        }

        
    }



    //handle events
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
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

        if(subscribe)
        {
            // Called when an ad request has successfully loaded.
            this._bannerAd.OnAdLoaded += this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this._bannerAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this._bannerAd.OnAdOpening += this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this._bannerAd.OnAdClosed += this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this._bannerAd.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            this._bannerAd.OnAdLoaded -= this.HandleOnAdLoaded;
            // Called when an ad request failed to load.
            this._bannerAd.OnAdFailedToLoad -= this.HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            this._bannerAd.OnAdOpening -= this.HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            this._bannerAd.OnAdClosed -= this.HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            this._bannerAd.OnAdLeavingApplication -= this.HandleOnAdLeavingApplication;
        }

        

    }

    private void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    private void OnDisable()
    {
        HandleBannerADEvents(false);
    }








}// add manager
