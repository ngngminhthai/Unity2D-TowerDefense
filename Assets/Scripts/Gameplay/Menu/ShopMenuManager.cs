using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ShopMenuManager : MonoBehaviour
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
        priceArchery.text = "Price: " + RoundFloat(ManageInfor.ArcheryStrength);
        priceWarrior.text = "Price: " + RoundFloat(ManageInfor.WarriorStrength);

       // goldText.text = "Gold:" + Gold.TotalGold;
        canvas.gameObject.SetActive(false);


    }

    public void ExitMenu()
    {
        canvas.gameObject.SetActive(false);

    }
    public void BuyArcher()
    {
        //Archery archy = GetComponent<Archery>();
        //Gold.MinusGold(ManageInfor.ArcheryStrength);
        Vector3 screenPosition = new Vector3(0, 0, 2);
        GameObject spaw = Instantiate<GameObject>(prefabArchery, screenPosition, Quaternion.identity);

    }
    public void Update()
    {
       // goldText.text = "Gold:" + Gold.TotalGold;

       //if (Gold.TotalGold < ManageInfor.ArcheryStrength)
       // {
       //     btnBuyArchery.interactable = false;
       //     btnUpdateArchery.interactable = false;
       // }
       // else
       // {
       //     btnBuyArchery.interactable = true;
       //     btnUpdateArchery.interactable = true;
       // }

       // if (Gold.TotalGold < ManageInfor.WarriorStrength)
       // {
       //     btnBuyWarrior.interactable = false;
       //     btnUpdateWarrior.interactable = false;
       // }
       // else
       // {
       //     btnBuyWarrior.interactable = true;
       //     btnUpdateWarrior.interactable = true;
       // }
       // priceArchery.text = "Price: " + RoundFloat(ManageInfor.ArcheryStrength);
       // priceWarrior.text = "Price: " + RoundFloat(ManageInfor.WarriorStrength);
    }
    // Update is called once per frame

    public void BuyWarrior()
    {
       // Gold.MinusGold(ManageInfor.WarriorStrength);
        Vector3 screenPosition = new Vector3(0, 0, 2);
        GameObject spaw = Instantiate<GameObject>(prefabWarrior, screenPosition, Quaternion.identity);
    }
    public void UpdateArcher()
    {

       
        ManageInfor.LevelUpArchery();
      //  Gold.MinusGold(ManageInfor.ArcheryStrength);
        levelArchery.text = "Level: " + ManageInfor.ArcheryLevel;
      
    }
    public void UpdateWarrior()
    {

        ManageInfor.LevelUpWarrior();
      //  Gold.MinusGold(ManageInfor.WarriorStrength);
        levelWarrior.text = "Level: " + ManageInfor.WarriorLevel;
    }
    public int RoundFloat(float value)
    {

        int myInt = (int)Math.Round(value);
        return myInt;
    }
}
