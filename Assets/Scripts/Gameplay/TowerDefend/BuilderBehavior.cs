using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
public class BuilderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;
    bool previousChangeCharacterInput = false;
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
  

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!previousChangeCharacterInput)
            {
                previousChangeCharacterInput = true;
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log("111"); 
                    canvas.gameObject.SetActive(true);
                }
            }
            else
            {
                previousChangeCharacterInput = false;
            }
            
        }
        
    }
    public void LoadShop()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);
            BuiderMenuManager.buildPosition = gameObject.transform.position;
            BuiderMenuManager.destroyBuilderBase = gameObject;
        }

    }

}
