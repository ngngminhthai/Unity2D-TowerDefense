using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        canvas.gameObject.SetActive(false);
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
}
