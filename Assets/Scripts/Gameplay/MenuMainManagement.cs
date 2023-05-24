using Assets.Scripts.Gameplay;
using Assets.Scripts.Gameplay.Units;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMainManagement : MonoBehaviour
{

    public static bool isLoaded = false;

    public void NewGameButtonOnClickEvent()
    {
        // Task 34 : Xóa toàn b? d? li?u and new game 
        SceneManager.LoadScene("finalsence");
    }

    public void ContinueButtonOnClickEvent()
    {
        //LoadSavedGame();
        isLoaded = true;
        SceneManager.LoadScene("finalsence");
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
        //ManageInfor.Reset();
        //SceneManager.LoadScene("finalsence");
        // Code moi  
        List<ObjectSave> objectSaves = new List<ObjectSave>();
        GameObject[] list = GameObject.FindGameObjectsWithTag("defenders");
        Tower tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();
        ObjectSaveTower objectSaveTower = new ObjectSaveTower { Health = tower.HitPoints };

        for (int i = 0; i < list.Length; i++)
        {
            //writer.WriteLine(list[i].transform.position.x + "," + list[i].transform.position.y + "," + list[i].transform.localScale.x);
            Defender defender = list[i].GetComponent<Defender>();
            if (defender.GetComponent<Defender>() is Archery)
                objectSaves.Add(new ObjectSave { X = defender.transform.position.x, Y = defender.transform.position.y, Health = defender.HitPoints, UnitType = "Archery" });
            if (defender.GetComponent<Defender>() is Warrion)
                objectSaves.Add(new ObjectSave { X = defender.transform.position.x, Y = defender.transform.position.y, Health = defender.HitPoints, UnitType = "Warrion" });
        }

        // Serialize the list of objects into a Json string 
        string jsonDefender = JsonConvert.SerializeObject(objectSaves);
        string jsonTower = JsonConvert.SerializeObject(objectSaveTower);

        // Using PlayerPrefs

        // Save Defender 
        PlayerPrefs.SetString("DefenderSave", jsonDefender);
        // Save Tower 
        PlayerPrefs.SetString("TowerSave", jsonTower);
    }


}
