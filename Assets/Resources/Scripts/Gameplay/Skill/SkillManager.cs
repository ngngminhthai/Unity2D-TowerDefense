using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    int chooseSkill = 0;

    [SerializeField]
    GameObject skillCanvas;

    [SerializeField]
    Button btnHypnosis;
    [SerializeField]
    Button btnHeal;


    [SerializeField]
    GameObject Hypnosis;

    [SerializeField]
    GameObject Health;


    //meteo

    [SerializeField]
    GameObject Meteo;

  
    //private Vector3 targetPosition;
    private Camera mainCamera;
    private bool isMoving = false;


    void Start()
    {

        chooseSkill = 0;
        skillCanvas.gameObject.SetActive(false);
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(chooseSkill != 0)
        {

            if (Input.GetMouseButtonDown(0)) // Bấm chuột trái
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10; // Khoảng cách từ camera đến mặt phẳng bạn muốn spawn GameObject

                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                switch (chooseSkill)
                {
                    case 1:
                        Instantiate(Hypnosis, worldPosition, Quaternion.identity);
                        break;
                    case 2:



                        Instantiate(Health, worldPosition, Quaternion.identity);



                        break;
                    case 3:
                        //targetPosition = worldPosition;
                        //targetPosition.z = 0f;
                        CreateMovingObject(worldPosition);
                        break;
                
                }
                // Spawn GameObject tại vị trí chuột

                chooseSkill = 0;
            }
          
        }
    }

    private void CreateMovingObject(Vector3 vector3)
    {
        Vector3 target = vector3;
        vector3.y = vector3.y+20f;
        GameObject newObj = Instantiate(Meteo, vector3, Quaternion.identity);
        MeteoDown objectMovement = newObj.GetComponent<MeteoDown>();
        objectMovement.SetTargetPosition(target);
        isMoving = true;
    }

    public void SkillHypnosis()
    {
        chooseSkill = 1;
        skillCanvas.gameObject.SetActive(false);
    }
    public void SkillHeal()
    {
        chooseSkill = 2;
        skillCanvas.gameObject.SetActive(false);
    }

    public void SkillMeteo()
    {
        chooseSkill = 3;
        skillCanvas.gameObject.SetActive(false);
    }

    public void Exit()
    {
        chooseSkill = 1;
        skillCanvas.gameObject.SetActive(false);
    }



}
