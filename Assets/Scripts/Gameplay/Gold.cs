using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Gold : IntEventInvoker
{
    [SerializeField]
    TextMeshProUGUI text;

    int totalGold;
    public int TotalGold
    {
        get { return totalGold; }
        set { totalGold = value; }
    }


    // GoldChangeEvent goldChange = new GoldChangeEvent();

    void Start()
    {

        totalGold = 100;

        EventManager.AddListener(EventName.GoldChangeEvent, PlusGold);
        EventManager.AddListener(EventName.ResetGold, Reset);
        
        
        unityEvents.Add(EventName.CheckGoldEvent, new CheckGoldEvent());
        EventManager.AddInvoker(EventName.CheckGoldEvent, this);
    }

    public void PlusGold(int value)
    {
        //int myInt = (int)Math.Round(value);
        TotalGold += value;
        unityEvents[EventName.CheckGoldEvent].Invoke(totalGold);
           
      
        
        
        //Debug.Log("vl :" + TotalGold);
    }
    public void Reset(int value)
    {
        totalGold = value;
    }

}
