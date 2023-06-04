using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Gold : MonoBehaviour
{
    int totalGold;
    public int TotalGold
    {
        get { return totalGold; }
        set { totalGold = value; }
    }


   // GoldChangeEvent goldChange = new GoldChangeEvent();
    private void Awake()
    {
       
        totalGold = 100;

        EventManager.AddListener(EventName.GoldChangeEvent, PlusGold);
    }

    void Start()
    {

        // add listener for PointsAddedEvent


    }

    public void PlusGold(int value)
    {
        //int myInt = (int)Math.Round(value);

        TotalGold += value;
        Debug.Log("vl :"+ TotalGold);
    }


    // Update is called once per frame
    //public  void MinusGold( int value)
    //{

    //    int myInt = (int)Math.Round(value); 

    //    TotalGold -= myInt;
    //  //  Debug.Log(totalGold);
    //}

}
