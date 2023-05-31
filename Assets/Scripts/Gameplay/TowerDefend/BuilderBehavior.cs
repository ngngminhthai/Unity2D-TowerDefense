using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;
    void Start()
    {
        
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
   
}
