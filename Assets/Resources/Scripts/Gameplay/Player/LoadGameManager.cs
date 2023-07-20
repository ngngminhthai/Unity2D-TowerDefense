using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Units;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject warrionPrefab;

    [SerializeField]
    public GameObject archeryPrefab;

    [SerializeField]
    public GameObject archeryTowerLevel1;

    [SerializeField]
    public GameObject archeryTowerLevel2;

    [SerializeField]
    public GameObject archeryTowerLevel3;

    [SerializeField]
    public GameObject mageTower1;

    [SerializeField]
    public GameObject mageTower2;

    [SerializeField]
    public GameObject mageTower3;

    [SerializeField]
    public GameObject AOETower1;

    [SerializeField]
    public GameObject AOETower2;

    [SerializeField]
    public GameObject AOETower3;

    [SerializeField]
    public GameObject milataryTower;

    // Start is called before the first frame update
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
            GameObject towerAttackObject;

            if (towerAttackSave.TowerType == "Archery")
            {
                if (towerAttackSave.Level == 1)
                    towerAttackObject = Instantiate(archeryTowerLevel1, position, Quaternion.identity);
                else if (towerAttackSave.Level == 2)
                    towerAttackObject = Instantiate(archeryTowerLevel2, position, Quaternion.identity);
                else
                    towerAttackObject = Instantiate(archeryTowerLevel3, position, Quaternion.identity);
            }

            else if (towerAttackSave.TowerType == "Milatary")
            {
                towerAttackObject = Instantiate(milataryTower, position, Quaternion.identity);
            }

            else if (towerAttackSave.TowerType == "AOE")
            {
                if (towerAttackSave.Level == 1)
                    towerAttackObject = Instantiate(AOETower1, position, Quaternion.identity);
                else if (towerAttackSave.Level == 2)
                    towerAttackObject = Instantiate(AOETower2, position, Quaternion.identity);
                else
                    towerAttackObject = Instantiate(AOETower3, position, Quaternion.identity);
            }

            else if (towerAttackSave.TowerType == "Mage")
            {
                if (towerAttackSave.Level == 1)
                    towerAttackObject = Instantiate(mageTower1, position, Quaternion.identity);
                else if (towerAttackSave.Level == 2)
                    towerAttackObject = Instantiate(mageTower2, position, Quaternion.identity);
                else
                    towerAttackObject = Instantiate(mageTower3, position, Quaternion.identity);
            }
            else
            {
                // Handle or log an error for unknown tower type, or provide some default behavior
                Debug.LogError("Unknown tower type: " + towerAttackSave.TowerType);
            }


        }

    }

}
