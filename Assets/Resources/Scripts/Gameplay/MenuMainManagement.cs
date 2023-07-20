using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Units;
using Assets.Scripts.Gameplay.Units.Defenders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMainManagement : IntEventInvoker
{

    public static bool isLoaded = false;
    int gold;
    public static int map;
    public void Start()
    {
        int gold = 100;
        unityEvents.Add(EventName.ResetGold, new ResetGold());
        EventManager.AddInvoker(EventName.ResetGold, this);
        // checkgold
        EventManager.AddListener(EventName.CheckGoldEvent, GetGold);
        //EventManager.AddListener(EventName.CheckGoldEvent,ResetGold );
    }
    public void ToResetGold(int value)
    {
        //int gold = -1 * value;


        unityEvents[EventName.ResetGold].Invoke(0);
    }
    public void NewGameButtonOnClickEvent()
    {

        SceneManager.LoadScene("map");
    }
    public void Map1()
    {
        map = 1;
        SceneManager.LoadScene("Map");
    }
    public void Map2()
    {
        map = 2;
        SceneManager.LoadScene("DesertMap");
    }
    public void Map3()
    {
        map = 3;
        SceneManager.LoadScene("FrozenMap");
    }

    public void ContinueButtonOnClickEvent()
    {
        //LoadSavedGame();
        isLoaded = true;
      
        switch (map)
        {
            case 1:
                SceneManager.LoadScene("map");
                break;
            case 2:
                SceneManager.LoadScene("DesertMap");
                break;
            case 3:
                SceneManager.LoadScene("FrozenMap");
                break;

            default:
                SceneManager.LoadScene("map");
                break;
        }
        Tower.colliders.Clear();
    }

    public void QuitButtonOnClickEvent()
    {
        Application.Quit();
    }
    public void SettingButton()
    {

        GameObject gameobject = GameObject.FindGameObjectWithTag("optionInGame");
        GameObject childGameObject = getGameChildObject(gameobject);
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }
    GameObject getGameChildObject(GameObject target)
    {
        // lay Transform cua doi tuong cha
        Transform parentTransform = target.transform;
        Transform childTransform = parentTransform.Find("BackGround");
        GameObject childGameObject = childTransform.gameObject;
        return childGameObject;
    }
    public void ExitSettingButton()
    {
        //   Debug.Log("Oke");
        GameObject gameobject = GameObject.FindGameObjectWithTag("optionInGame");
        GameObject childGameObject = getGameChildObject(gameobject);
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }
    public void SurrenderButton()
    {
        ManageInfor.Reset();
        SceneManager.LoadScene("GameOver");
    }
    public void ExitSettingButton2()
    {
        // Task 34 : Xóa toàn b? d? li?u and new game 
        SceneManager.LoadScene("Menu");
    }
    public void RestGame()
    {
        // Save game 
        List<ObjectSave> objectSavesDefender = new List<ObjectSave>(); // Defender
        List<ObjectSave> objectSavesAttracker = new List<ObjectSave>(); // Attacker
        List<ObjectSaveTowerAttack> objectSavesTowerAttack = new List<ObjectSaveTowerAttack>(); // Tower Attack

        // Find all 
        GameObject[] Defenderlist = GameObject.FindGameObjectsWithTag("defenders");
        GameObject[] Attracklist = GameObject.FindGameObjectsWithTag("attackers");
        GameObject[] TowerAttackList = GameObject.FindGameObjectsWithTag("TowerAttack");

        // HeadQuarter 
        HeadQuarter tower = GameObject.FindGameObjectWithTag("tower").GetComponent<HeadQuarter>();
        ObjectSaveTower objectSaveTower = new ObjectSaveTower { Health = tower.HitPoints };

        // Save Defender
        for (int i = 0; i < Defenderlist.Length; i++)
        {
            //writer.WriteLine(list[i].transform.position.x + "," + list[i].transform.position.y + "," + list[i].transform.localScale.x);
            Defender defender = Defenderlist[i].GetComponent<Defender>();
            if (defender.GetComponent<Defender>() is Archery)
                objectSavesDefender.Add(new ObjectSave { X = defender.transform.position.x, Y = defender.transform.position.y, Health = defender.HitPoints, UnitType = "Archery" });
            if (defender.GetComponent<Defender>() is Warrion)
                objectSavesDefender.Add(new ObjectSave { X = defender.transform.position.x, Y = defender.transform.position.y, Health = defender.HitPoints, UnitType = "Warrion" });
        }
        // Save Attacker 
        for (int i = 0; i < Attracklist.Length; i++)
        {
            Attacker attacker = Attracklist[i].GetComponent<Attacker>();
            if (attacker.GetComponent<Attacker>() is Banshee)
                objectSavesAttracker.Add(new ObjectSave { X = attacker.transform.position.x, Y = attacker.transform.position.y, Health = attacker.HitPoints, UnitType = "Banshee" });
            if (attacker.GetComponent<Attacker>() is Harpy)
                objectSavesAttracker.Add(new ObjectSave { X = attacker.transform.position.x, Y = attacker.transform.position.y, Health = attacker.HitPoints, UnitType = "Harpy" });
            if (attacker.GetComponent<Attacker>() is Monitor)
                objectSavesAttracker.Add(new ObjectSave { X = attacker.transform.position.x, Y = attacker.transform.position.y, Health = attacker.HitPoints, UnitType = "Monitor" });
            if (attacker.GetComponent<Attacker>() is Ogre)
                objectSavesAttracker.Add(new ObjectSave { X = attacker.transform.position.x, Y = attacker.transform.position.y, Health = attacker.HitPoints, UnitType = "Ogre" });
        }
        // Save TowerAttack
        for (int i = 0; i < TowerAttackList.Length; i++)
        {
            TowerInformation towerAttack = TowerAttackList[i].GetComponent<TowerInformation>();
            objectSavesTowerAttack.Add(new ObjectSaveTowerAttack { X = towerAttack.transform.position.x, Y = towerAttack.transform.position.y, Level = towerAttack.getLevel, UnitType = towerAttack.getType });
        }

        // Serialize the list of objects into a Json string 
        string jsonDefender = JsonConvert.SerializeObject(objectSavesDefender);
        string jsonAttacker = JsonConvert.SerializeObject(objectSavesAttracker);
        string jsonTower = JsonConvert.SerializeObject(objectSaveTower);
        string jsonTowerAttack = JsonConvert.SerializeObject(objectSavesTowerAttack);
        string jsonGold = JsonConvert.SerializeObject(gold.ToString());
        // Using PlayerPrefs

        // Save Defender 
        PlayerPrefs.SetString("DefenderSave", jsonDefender);
        // Save Attacker
        PlayerPrefs.SetString("AttackerSave", jsonAttacker);
        // Save Tower 
        PlayerPrefs.SetString("TowerSave", jsonTower);
        // Save Tower Attack
        PlayerPrefs.SetString("TowerAttackSave", jsonTowerAttack);
        //save gold
        PlayerPrefs.SetString("GoldSave", jsonGold);
    }

    public void GetGold(int value)
    {
        gold = value;
    }
}
