using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameObject towerLevel02;

    [SerializeField]
    GameObject towerLevel03;

    [SerializeField]
    int currentLevel;

    [SerializeField]
    GameObject BuiderBase;

    [SerializeField]
    TextMeshProUGUI LevelText;

    public Button buttonToDisable;
    void Start()
    {
        if (currentLevel == 3)
            buttonToDisable.interactable = false; 
        int levelUp = currentLevel + 1; 
        canvas.gameObject.SetActive(false);
        LevelText.text = "Level: " + levelUp;
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadShop()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);

        }

    }
    void OnMouseDown()
    {
        //Vector3 oldObjectPosition = transform.position;
        //Quaternion oldObjectRotation = transform.rotation;
        Debug.Log("Innnnnnnn");
        LoadShop();
    }
    public void ExitMenu()
    {
        canvas.gameObject.SetActive(false);

    }
    public void UpdateMenu()
    {
        Debug.Log("In");
        if(currentLevel == 1)
            Instantiate(towerLevel02, transform.position, transform.rotation);
        else 
            Instantiate(towerLevel03, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    public void DestroyMenu()
    {
        Instantiate(BuiderBase, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
