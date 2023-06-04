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
    int currentLevel;

    private Camera mainCamera;
    bool previousChangeCharacterInput = false;
    GameObject objectClick;
    void Start()
    {
        if (currentLevel == 3)
            buttonToDisable.interactable = false; 
        int levelUp = currentLevel + 1; 
        canvas.gameObject.SetActive(false);
        LevelText.text = "Level: " + levelUp;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit;
            Vector2 rayOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition); // Chuyển vị trí con trỏ chuột thành World Space

            // Phát ra Ray từ vị trí con trỏ chuột và kiểm tra va chạm với Collider2D
            hit = Physics2D.RaycastAll(rayOrigin, Vector2.zero);

            if (hit.Length > 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    // Debug.Log("a");
                    if (hit[i].collider.tag == "TowerAttack")
                    {
                        objectClick = hit[i].collider.gameObject;
                        LoadShop();
                        break;
                    }
                }
            }



        }
    }
    public void LoadShop()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);

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
        canvas.gameObject.SetActive(false);

    }
    public void UpdateMenu()
    {
        Debug.Log("In");
        if (currentLevel == 1)
            Instantiate(towerLevel02, objectClick.transform.position, objectClick.transform.rotation);
        else
            Instantiate(towerLevel03, objectClick.transform.position, objectClick.transform.rotation);
        Destroy(objectClick);
    }
    public void DestroyMenu()
    {
        Instantiate(BuiderBase, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
