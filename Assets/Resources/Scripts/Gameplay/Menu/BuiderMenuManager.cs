using Assets.Scripts.Gameplay.Units.Defenders;
using Assets.Scripts.Gameplay.Units.Towers;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuiderMenuManager : IntEventInvoker
{
   
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
    [SerializeField]
    Button btnBuyMili;
    //[SerializeField]
    //Button btnUpdateArchery;
    //[SerializeField]
    //Button btnUpdateWarrior;

    [SerializeField]
    GameObject prefabAOETower;

    [SerializeField]
    GameObject prefabMageTower;

    [SerializeField]
    GameObject prefabArcheryTower;
    [SerializeField]
    GameObject prefabMiliTower;

    private TowerFactory _towerFactory;


    public static Vector2 buildPosition;
    public static GameObject destroyBuilderBase;

    void Start()
    {
        unityEvents.Add(EventName.GoldChangeEvent, new GoldChangeEvent());
        EventManager.AddInvoker(EventName.GoldChangeEvent, this);
        // checkgold

        EventManager.AddListener(EventName.CheckGoldEvent, DisableButton);


        // goldText.text = "Gold:" + Gold.TotalGold;
        canvas.gameObject.SetActive(false);
        _towerFactory = new TowerFactory();


        priceTowerArchery.text = "Price: 80 ";
        priceTowerMage.text = "Price: 80";
        priceTowerAOE.text = "Price: 80";

        //goldText.text = "Gold:" + Gold.TotalGold;
        canvas.gameObject.SetActive(false);


    }

    public void ExitMenu()
    {
        canvas.gameObject.SetActive(false);

    }

    public void Update()
    {


    }
    // Update is called once per frame
    public void BuyTowerArcher()
    {
        unityEvents[EventName.GoldChangeEvent].Invoke(-80);
        Tower tower = _towerFactory.GetTower("Archery");
        tower.Create(buildPosition, prefabArcheryTower);
        canvas.gameObject.SetActive(false);
        DestroyBuilderBase();

    }
    public void BuyTowerMage()
    {
        unityEvents[EventName.GoldChangeEvent].Invoke(-80);
        Tower tower = _towerFactory.GetTower("Mage");
        tower.Create(buildPosition, prefabMageTower);
        canvas.gameObject.SetActive(false);
        DestroyBuilderBase();

    }
    public void BuyTowerAOE()
    {
        unityEvents[EventName.GoldChangeEvent].Invoke(-80);
        Tower tower = _towerFactory.GetTower("AOE");
        tower.Create(buildPosition, prefabAOETower);
        canvas.gameObject.SetActive(false);
        DestroyBuilderBase();
    }


    public void BuyMilataryTower()
    {
        unityEvents[EventName.GoldChangeEvent].Invoke(-80);
        NonAttackTower tower = _towerFactory.GetNonAttackTower("Milatary");
        tower.Create(buildPosition, prefabMiliTower);
        canvas.gameObject.SetActive(false);
        DestroyBuilderBase();
    }

    public void DestroyBuilderBase()
    {
        if (destroyBuilderBase != null)
        {
            Destroy(destroyBuilderBase);
        }
    }

    public int RoundFloat(float value)
    {

        int myInt = (int)Math.Round(value);
        return myInt;
    }
    public void DisableButton(int value)
    {
        if (value < 80)
        {
            btnBuyAOE.interactable = false;
            btnBuyArchery.interactable = false;
            btnBuyMage.interactable = false;
            btnBuyMili.interactable = false;
        }
        else
        {
            btnBuyAOE.interactable = true;
            btnBuyArchery.interactable = true;
            btnBuyMage.interactable = true;
            btnBuyMili.interactable = true;
        }
    }
}
