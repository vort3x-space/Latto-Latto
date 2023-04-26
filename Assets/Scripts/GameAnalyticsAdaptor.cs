using System;
using System.Collections;
using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;


public class GameAnalyticsAdaptor : Singleton<GameAnalyticsAdaptor>
{
    private void Start()
    {
        GameAnalytics.Initialize();
    }

    public void NewBusinessEventIOS(string currency, int amount, string itemType, string itemId, string cartType,
        IDictionary<string, object> receipt)
    {
        GameAnalytics.NewBusinessEvent(currency, amount, itemType, itemId, cartType, receipt);
        //need revise
    }

    public void NewBusinessEventGooglePlay(string currency, int amount, string itemType, string itemId, string cartType,
        IDictionary<string, object> receipt, bool signature)
    {
        GameAnalytics.NewBusinessEvent(currency, amount, itemType, itemId, cartType, receipt, signature);
        //need revise
    }

    public void NewResourceEvent(GAResourceFlowType sink, string currency, float amount, string itemType, string itemId)
    {
        GameAnalytics.NewResourceEvent(sink, currency, amount, itemType, itemId);
    }


    public void NewProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02,
        string progression03, int score)
    {
        GameAnalytics.NewProgressionEvent(progressionStatus, progression01, progression02, progression03, score);
    }

    public void NewDesignEvent(string eventName, float eventValue)
    {
        GameAnalytics.NewDesignEvent(eventName, eventValue);
    }

    public void NewErrorEvent(GAErrorSeverity severity, string message)
    {
        GameAnalytics.NewErrorEvent(severity, message);
    }

    public void SetCustomDimension(string customDimension, int numberofDimension)
    {
        if (numberofDimension == 1)
        {
            GameAnalytics.SetCustomDimension01(customDimension);
        }
        else if (numberofDimension == 2)
        {
            GameAnalytics.SetCustomDimension02(customDimension);
        }
        else if (numberofDimension == 3)
        {
            GameAnalytics.SetCustomDimension03(customDimension);
        }
        else
        {
            Debug.LogError("Wrong Custom Dimension init");
        }
    }
}