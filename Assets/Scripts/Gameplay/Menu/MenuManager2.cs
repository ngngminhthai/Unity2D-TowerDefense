using UnityEngine;

public class MenuManager2 : MonoBehaviour
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
