//
//  Copyright 2019  Fyber N.V
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

using UnityEngine;
using FyberPlugin;
using System;

/// <summary>
/// The Main Scene,
/// responsible for starting the FairBid SDK and displaying the different ads - banner, interstitial, rewarded
/// </summary>
public class MainScene : MonoBehaviour {

    /// <summary>
    /// The publisher id provided through the Fyber console
    /// "12456" can be used a sample application.
    /// </summary>
    /// TODO replace with your own app id.
    private const String PUBLISHER_APP_ID = "12456";

    private Ad ofwAd;

    void OnEnable()
    {
        Debug.Log("OfferWallScene: OnEnable");
        FyberCallback.AdAvailable += OnAdAvailable;
        FyberCallback.AdNotAvailable += OnAdNotAvailable;
        FyberCallback.RequestFail += OnRequestFail;
    }

    void OnDisable()
    {
        FyberCallback.AdAvailable -= OnAdAvailable;
        FyberCallback.AdNotAvailable -= OnAdNotAvailable;
        FyberCallback.RequestFail -= OnRequestFail;
    }


    private void OnAdAvailable(Ad ad)
    {
        Debug.Log("OnAdAvailable. Showing ofw");
        ad.Start();
    }

    private void OnAdNotAvailable(AdFormat adFormat)
    {
        // not yet implemented
        Debug.Log("OnAdNotAvailable: " + adFormat);
    }

    private void OnRequestFail(RequestError error)
    {
        // process error
        Debug.Log("OnRequestError: " + error.Description);
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        setOfwSdkVersionTextView();
        StartOfwEdgeSdk(PUBLISHER_APP_ID);
    }

    /// <summary>
    /// Changes the current scene.
    /// </summary>
    /// <param name="sceneName">Scene name.</param>
    public void ShowOfw()
    {
        Debug.Log("Getting ready to show OFW");
        OfferWallRequester.Create().Request();              
    }

    /// <summary>
    /// Helper method for initializing the SDK with the given app id
    /// </summary>
    /// <param name="appId">The app id provided through the Fyber console</param>
    private void StartOfwEdgeSdk(String pulisherId) {
        Fyber.With(pulisherId).Start();

        // Alternative starts
        
        // chaining with all options                              
        // Fyber.With(pulisherId).WithUserId(userId)
        //                       .WithSecurityToken(securityToken)
        //                       .WithParameters(paramaters)
        //                       .Start();
        
        // instantitation of Fyber and Setting & Setting global settings                                  
        // Fyber fyberSDK = Fyber.With(pulisherId);
        // Settings fyberSDKSetting = fyberSDK.Start();
        // fyberSDKSetting.NotifyUserOnReward(true)
        //                .CloseOfferWallOnRedirect(true)
        //                .AddParameters(paramters)
        //                .AddParameter(parameter)
        //                .UpdateUserId(newUserId);
    }


    /// <summary>
    /// Helper method for displaying the FairBid SDK version
    /// </summary>
    private void setOfwSdkVersionTextView()
    {
        // Not yet implemented
    }
}
