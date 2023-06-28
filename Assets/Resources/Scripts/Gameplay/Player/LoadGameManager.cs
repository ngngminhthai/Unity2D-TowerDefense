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

            // Truoc kia
            // defenderObject.GetComponent<Defender>().HitPoints = obj.Health;

            // Moi Fix :
            defenderObject.GetComponent<Defender>().healthBar.SetHealth(obj.Health);
        }
    }

}
