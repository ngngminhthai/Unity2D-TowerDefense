using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Units;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LoadGameManager :  IntEventInvoker
{
    [SerializeField]
    public GameObject warrionPrefab;

    [SerializeField]
    public GameObject archeryPrefab;

    [SerializeField]
    public GameObject towerPrefab;
    //[SerializeField]
    //TextMeshProUGUI goldText;
    // Start is called before the first frame update
    private void Awake()
    {
        unityEvents.Add(EventName.ResetGold, new ResetGold());
        EventManager.AddInvoker(EventName.ResetGold, this);
    }
    void Start()
    {

        if (MenuMainManagement.isLoaded)
        {
            LoadSavedGame();
            MenuMainManagement.isLoaded = false;
        }
        


    }
    public void LoadSavedGame()
    {
       
       
        // Load Defender data
        string jsonDefender = PlayerPrefs.GetString("DefenderSave");
        List<ObjectSave> objectSaves = JsonConvert.DeserializeObject<List<ObjectSave>>(jsonDefender);


        // Load Tower data
        string jsonTower = PlayerPrefs.GetString("TowerSave");
        ObjectSaveTower objectSaveTower = JsonConvert.DeserializeObject<ObjectSaveTower>(jsonTower);

        // Instantiate Tower with saved health
        GameObject towerObject = GameObject.FindGameObjectWithTag("tower");
        HeadQuarter tower = towerObject.GetComponent<HeadQuarter>();
        tower.HitPoints = objectSaveTower.Health;

        foreach (ObjectSave obj in objectSaves)
        {
            Vector3 position = new Vector3(obj.X, obj.Y, 0);
            GameObject defenderObject;
            if (obj.UnitType == "Archery")
                defenderObject = Instantiate(archeryPrefab, position, Quaternion.identity);
            else
                defenderObject = Instantiate(warrionPrefab, position, Quaternion.identity);


            defenderObject.GetComponent<Defender>().HitPoints = obj.Health;
            defenderObject.GetComponent<Defender>().MaxHitPoint = ManageInfor.WarriorHitPoint;


            /*            defenderObject.GetComponent<Defender>().HitPoints = 1;
            */
            /*// Truoc kia
            defenderObject.GetComponent<Unit>().BaseHitPoints = 1;

            // Moi Fix :
            defenderObject.GetComponent<Unit>().healthBar.SetHealth(1);
            //Debug.Log(defenderObject.GetComponent<Defender>().HitPoints);*/
        }

        string jsonTowerAttack = PlayerPrefs.GetString("TowerAttackSave");
        List<ObjectSaveTowerAttack> towerAttacks = JsonConvert.DeserializeObject<List<ObjectSaveTowerAttack>>(jsonTowerAttack);

        foreach (ObjectSaveTowerAttack towerAttackSave in towerAttacks)
        {
            Vector3 position = new Vector3(towerAttackSave.X, towerAttackSave.Y, 0);

            // Check for BuilderBase at the position
            Collider2D builderBaseCollider = Physics2D.OverlapCircle(position, 0.1f);  // assuming a small radius for overlap check
            if (builderBaseCollider != null && builderBaseCollider.CompareTag("BuilderBase"))
            {
                Destroy(builderBaseCollider.gameObject);
            }

           GameObject towerAttackObject = Instantiate(towerPrefab, position, Quaternion.identity);

            /*  // Assuming TowerInformation component is what you use to store tower details
              TowerInformation towerAttackInfo = towerAttackObject.GetComponent<TowerInformation>();
              towerAttackInfo.getLevel = towerAttackSave.Level;  // Assuming 'getLevel' is a public variable.*/
        }
        string stringGold = PlayerPrefs.GetString("GoldSave");
       int intGold = int.Parse(JsonConvert.DeserializeObject<string>(stringGold));

        unityEvents[EventName.ResetGold].Invoke(intGold);
       // goldText.text = "Gold : " + intGold;
    }

}
