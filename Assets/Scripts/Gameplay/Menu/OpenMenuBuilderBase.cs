
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenMenuBase : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;
    void Start()
    {
       
    }
    public void LoadShop()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
