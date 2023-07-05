using Assets.Resources.Scripts.Gameplay.Units.Towers;
using TMPro;
using UnityEngine;

public class MenuManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Canvas canvas;

    GameObject TowerModeBtn;


    void Start()
    {
        TowerModeBtn = GameObject.Find("Text Button Tower Mode");
    }

    public void LoadShop()
    {
        if (!canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(true);

        }

    }

    public void ChangeTowerMode()
    {
        if (TowerModeAttackManager.Mode == 1)
        {
            TowerModeAttackManager.Mode = 0;
            Debug.Log("Currently attack closest monsters");
            TowerModeBtn.GetComponent<TextMeshProUGUI>().text = "Tower Mode(Closest)";
        }
        else
        {
            Debug.Log("Currently attack weakest monsters");
            TowerModeAttackManager.Mode = 1;
            TowerModeBtn.GetComponent<TextMeshProUGUI>().text = "Tower Mode(Weakest)";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
