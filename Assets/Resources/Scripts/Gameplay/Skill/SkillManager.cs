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



    void Start()
    {

        chooseSkill = 0;
        skillCanvas.gameObject.SetActive(false);
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
                        Console.WriteLine("Số 2");
                        break;
                    case 3:
                       
                        break;
                
                }
                // Spawn GameObject tại vị trí chuột

                chooseSkill = 0;
            }
          
        }
    }



    public void SkillHypnosis()
    {
        chooseSkill = 1;
        skillCanvas.gameObject.SetActive(false);
    }

}
