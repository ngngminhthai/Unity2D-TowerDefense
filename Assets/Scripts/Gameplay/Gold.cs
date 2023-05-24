using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    static int  totalGold = 100;
    public static int TotalGold { 
        get { return totalGold; }  
        set { totalGold = value; } }
    
   
    


    // Update is called once per frame
    public static void MinusGold( float value)
    {
      
        int myInt = (int)Math.Round(value); 

        TotalGold -= myInt;
      //  Debug.Log(totalGold);
    }
    public static void PlusGold( float value)
    {
        int myInt = (int)Math.Round(value);

        TotalGold += myInt;
      //  Debug.Log(totalGold);
    }
}
