using UnityEngine;

public class BuilderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;
    private Camera mainCamera;
    bool previousChangeCharacterInput;

    GameObject objectClick;
    void Start()
    {
        canvas.gameObject.SetActive(false);
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
                    //Debug.Log("a");
                    if (hit[i].collider.tag == "BuilderBase")
                    {
                        objectClick = hit[i].collider.gameObject;
                        LoadShop2();
                        break;
                    }
                }
            }



        }
    }
    public void LoadShop2()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);

            // Sử dụng biến objectClick để lấy position của game object được bấm vào
            BuiderMenuManager.buildPosition = objectClick.transform.position;
            BuiderMenuManager.destroyBuilderBase = objectClick;
        }

    }
    

}
