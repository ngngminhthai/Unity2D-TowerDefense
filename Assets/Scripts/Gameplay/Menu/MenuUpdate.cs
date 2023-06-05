using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas updateMenuAction;

    [SerializeField]
    Canvas buyMenu;


    [SerializeField]
    TextMeshProUGUI LevelText;
    [SerializeField]
    public Button buttonToDisable;

   
    TowerInformation tower;
    private Camera mainCamera;
    bool previousChangeCharacterInput = false;



    GameObject objectClick;
    [SerializeField]
    int currentLevel;

    void Start()
    {
        mainCamera = Camera.main;
      
        updateMenuAction.gameObject.SetActive(false);
        //LevelText.text = "Level: " + levelUp;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!previousChangeCharacterInput)
            {
                RaycastHit2D[] hit;
                Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                // Phát ra Ray từ vị trí con trỏ chuột và kiểm tra va chạm với Collider2D
                hit = Physics2D.RaycastAll(rayOrigin, Vector2.zero);
                bool isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
                if (hit.Length > 0 && !isOverUI )
                {
                    for (int i = 0; i < hit.Length; i++)
                    {
                        // Debug.Log("a");
                        if (hit[i].collider.tag == "TowerAttack")
                        {
                            objectClick = hit[i].collider.gameObject;
                            tower = hit[i].collider.GetComponent<TowerInformation>();
                            currentLevel = tower.level;
                            LoadShop();
                            break;
                        }
                        //Debug.Log("a");
                        if (hit[i].collider.tag == "BuilderBase")
                        {
                            objectClick = hit[i].collider.gameObject;
                            LoadShop2();
                            break;
                        }

                    }
                    previousChangeCharacterInput = true;
                }
            }




        }
        else
        {
            previousChangeCharacterInput = false;
        }
    }
    public void LoadShop()

    {
        if (!updateMenuAction.gameObject.activeSelf)
        {
            

            updateMenuAction.gameObject.SetActive(true);

        }
        if (currentLevel == 3)
        {
            buttonToDisable.interactable = false;
        }

    }
    //void OnMouseDown()
    //{
    //    //Vector3 oldObjectPosition = transform.position;
    //    //Quaternion oldObjectRotation = transform.rotation;
    //    Debug.Log("Innnnnnnn");
    //    LoadShop();
    //}
    public void ExitMenu()
    {
        updateMenuAction.gameObject.SetActive(false);

    }
    public void UpdateMenu()
    {
        
        Debug.Log("In");
        if (currentLevel == 1)
            Instantiate(tower.towerLevel02, objectClick.transform.position, objectClick.transform.rotation);
        ExitMenu();
        Destroy(objectClick);
        if (currentLevel==2)
            Instantiate(tower.towerLevel03, objectClick.transform.position, objectClick.transform.rotation);
        ExitMenu();
        Destroy(objectClick);
        if (currentLevel == 3)
        {
            buttonToDisable.interactable = false;
        }
      
        
    }
    public void DestroyMenu()
    {
        Instantiate(tower.BuiderBase, objectClick.transform.position, objectClick.transform.rotation);
        Destroy(objectClick);
    }


    public void LoadShop2()
    {
        if (!buyMenu.gameObject.activeSelf)
        {
           buyMenu.gameObject.SetActive(true);

            // Sử dụng biến objectClick để lấy position của game object được bấm vào
            BuiderMenuManager.buildPosition = objectClick.transform.position;
            BuiderMenuManager.destroyBuilderBase = objectClick;
        }

    }
}
