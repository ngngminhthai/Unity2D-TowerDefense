using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShopMenuManager : IntEventInvoker
{
    [SerializeField]
    TextMeshProUGUI goldText;
    [SerializeField]
    public Canvas canvas;
    [SerializeField]
    GameObject prefabArchery;
    [SerializeField]
    GameObject prefabWarrior;


    [SerializeField]
    TextMeshProUGUI priceArchery;
    [SerializeField]
    TextMeshProUGUI priceWarrior;

    //level
    [SerializeField]
    TextMeshProUGUI levelArchery;
    [SerializeField]
    TextMeshProUGUI levelWarrior;

    //btn
    [SerializeField]
    Button btnBuyArchery;
    [SerializeField]
    Button btnBuyWarrior;

    [SerializeField]
    Button btnUpdateArchery;
    [SerializeField]
    Button btnUpdateWarrior;

    void Start()
    {
        goldText.text = "Gold: 100";
        priceArchery.text = "Price: " + RoundFloat(ManageInfor.ArcheryStrength);
        priceWarrior.text = "Price: " + RoundFloat(ManageInfor.WarriorStrength);

       // goldText.text = "Gold:" + Gold.TotalGold;
        canvas.gameObject.SetActive(false);

        unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
        EventManager.AddInvoker(EventName.GoldChangeEvent, this);
        // checkgold

        EventManager.AddListener(EventName.CheckGoldEvent, DisableButton);
        //goldText.text = "Gold: 100";
    }

    public void ExitMenu()
    {
        canvas.gameObject.SetActive(false);

    }
   
    public void Update()
    {
      
    }
    // Update is called once per frame
    public void BuyArcher()
    {
        //goldText 
        //Archery archy = GetComponent<Archery>();
        //Gold.MinusGold(ManageInfor.ArcheryStrength);
        unityEvents[EventName.GoldChangeEvent].Invoke(Caculate(ManageInfor.ArcheryStrength));
        Vector3 screenPosition = new Vector3(0, 0, 2);
        GameObject spaw = Instantiate<GameObject>(prefabArchery, screenPosition, Quaternion.identity);

    }
    public void BuyWarrior()
    {
        // Gold.MinusGold(ManageInfor.WarriorStrength);
        unityEvents[EventName.GoldChangeEvent].Invoke(Caculate(ManageInfor.WarriorStrength));
        Vector3 screenPosition = new Vector3(0, 0, 2);
        GameObject spaw = Instantiate<GameObject>(prefabWarrior, screenPosition, Quaternion.identity);
    }
    public void UpdateArcher()
    {

        unityEvents[EventName.GoldChangeEvent].Invoke(Caculate(ManageInfor.ArcheryStrength));
        ManageInfor.LevelUpArchery();
      
        //  Gold.MinusGold(ManageInfor.ArcheryStrength);
        levelArchery.text = "Level: " + ManageInfor.ArcheryLevel;
      
    }
    public void UpdateWarrior()
    {
        unityEvents[EventName.GoldChangeEvent].Invoke(Caculate(ManageInfor.WarriorStrength));
        ManageInfor.LevelUpWarrior();
        
        //  Gold.MinusGold(ManageInfor.WarriorStrength);
        levelWarrior.text = "Level: " + ManageInfor.WarriorLevel;
    }
    public int RoundFloat(float value)
    {

        int myInt = (int)Math.Round(value);
        return myInt;
    }
    public void DisableButton(int value)
    {
     
        goldText.text = "Gold:" + value;

        if (value < ManageInfor.ArcheryStrength)
        {
            btnBuyArchery.interactable = false;
            btnUpdateArchery.interactable = false;
        }
        else
        {
            btnBuyArchery.interactable = true;
            btnUpdateArchery.interactable = true;
        }

        if (value < ManageInfor.WarriorStrength)
        {
            btnBuyWarrior.interactable = false;
            btnUpdateWarrior.interactable = false;
        }
        else
        {
            btnBuyWarrior.interactable = true;
            btnUpdateWarrior.interactable = true;
        }
        priceArchery.text = "Price: " + RoundFloat(ManageInfor.ArcheryStrength);
        priceWarrior.text = "Price: " + RoundFloat(ManageInfor.WarriorStrength);
    }
    public int Caculate(float value)
    {
        int result = Convert.ToInt32(Math.Ceiling(value));
        return -1*result;
    }
}
