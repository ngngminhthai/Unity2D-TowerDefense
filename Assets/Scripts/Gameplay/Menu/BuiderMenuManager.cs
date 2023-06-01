using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuiderMenuManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI goldText;
    [SerializeField]
    public Canvas canvas;
    //[SerializeField]
    //GameObject prefabTowerArchery;
    //[SerializeField]
    //GameObject prefabTowerMage;
    //[SerializeField]
    //GameObject prefabTowerAOE;

    [SerializeField]
    TextMeshProUGUI priceTowerArchery;
    [SerializeField]
    TextMeshProUGUI priceTowerMage;
    [SerializeField]
    TextMeshProUGUI priceTowerAOE;
    //level
  

    //btn
    [SerializeField]
    Button btnBuyArchery;
    [SerializeField]
    Button btnBuyMage;
    [SerializeField]
    Button btnBuyAOE;

    //[SerializeField]
    //Button btnUpdateArchery;
    //[SerializeField]
    //Button btnUpdateWarrior;

    void Start()
    {
        priceTowerArchery.text = "Price: 1 ";
        priceTowerMage.text = "Price: 1"  ;
        priceTowerAOE.text = "Price: 1"  ;

        goldText.text = "Gold:" + Gold.TotalGold;
        canvas.gameObject.SetActive(false);


    }

    public void ExitMenu()
    {
        canvas.gameObject.SetActive(false);

    }
   
    public void Update()
    {
        goldText.text = "Gold:" + Gold.TotalGold;

        //if (Gold.TotalGold < ManageInfor.ArcheryStrength)
        //{
        //    btnBuyArchery.interactable = false;
        //    btnUpdateArchery.interactable = false;
        //}
        //else
        //{
        //    btnBuyArchery.interactable = true;
        //    btnUpdateArchery.interactable = true;
        //}

        //if (Gold.TotalGold < ManageInfor.WarriorStrength)
        //{
        //    btnBuyWarrior.interactable = false;
        //    btnUpdateWarrior.interactable = false;
        //}
        //else
        //{
        //    btnBuyArchery.interactable = true;
        //    btnUpdateWarrior.interactable = true;
        //}
       
    }
    // Update is called once per frame
    public void BuyTowerArcher()
    {
        //Archery archy = GetComponent<Archery>();
        // Gold.MinusGold(ManageInfor.ArcheryStrength);
        Vector3 screenPosition = new Vector3(0, 0, 2);
        //GameObject spaw = Instantiate<GameObject>(prefabArchery, screenPosition, Quaternion.identity);

    }
    public void BuyTowerMage()
    {
        //Gold.MinusGold(ManageInfor.WarriorStrength);
        //Vector3 screenPosition = new Vector3(0, 0, 2);
        //GameObject spaw = Instantiate<GameObject>(prefabWarrior, screenPosition, Quaternion.identity);
    }
    public void BuyTowerAOE()
    {
        //Gold.MinusGold(ManageInfor.WarriorStrength);
        //Vector3 screenPosition = new Vector3(0, 0, 2);
        //GameObject spaw = Instantiate<GameObject>(prefabWarrior, screenPosition, Quaternion.identity);
    }

    public int RoundFloat(float value)
    {

        int myInt = (int)Math.Round(value);
        return myInt;
    }
}
