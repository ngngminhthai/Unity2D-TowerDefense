using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkill : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);


        }
        else
        {
            canvas.gameObject.SetActive(false);
        }

    }

}
