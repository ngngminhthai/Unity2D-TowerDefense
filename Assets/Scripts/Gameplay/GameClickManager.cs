using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class GameClickManager : MonoBehaviour
{
    public static GameObject selectedTarget;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTarget != null && selectedTarget.GetComponent<Defender>() is Defender)
            {
                selectedTarget.GetComponent<AgentMoventMent>().ContinueMoving();
            }
            RaycastHit2D hit = default;

            //lay ra collider khi duoc click vao
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.isTrigger == false)
                {
                    hit = hits[i];
                }
            }

            if (hit.collider != default)
            {

                GameObject target = hit.collider.gameObject;
                //Debug.Log(target);


                //Neu (target.CompareTag("Attacker") || target.CompareTag("Defender")) thì moii xu lý( cái này sau ae code hoàn chinh bo sung sau )
                // Kiem tra neu ?oi t??ng ?a ?uoc ch?n tr??c ?ó và không phai là ?oi t??ng hi?n t?i
                if (selectedTarget != null && selectedTarget != target)
                {
                    // An thanh máu cua doi tuong trc dó
                    //HideHealthBar(selectedTarget);
                    if (selectedTarget != null && selectedTarget.GetComponent<Defender>() != null)
                        selectedTarget.GetComponent<Defender>().selection.GetComponent<SpriteRenderer>().enabled = false;

                }

                //neu sau doi selectedTarget hien tai la defenders va doi tuong vua duoc click vao la attackers thi se di chuyen den
                //neu sau doi selectedTarget hien tai la attackers va doi tuong vua duoc click vao la defenders thi se khong di chuyen
                if (selectedTarget != null)
                {
                    bool canMove = true;
                    //neu doi tuong selected khong phai la defenders thi khong duoc phep di chuyen
                    if (selectedTarget.tag != "defenders")
                    {
                        canMove = false;
                    }

                    //neu doi tuong duoc click vao la attackers va selectedtarget la defenders thi se di chuyen den doi tuong do 
                    //va gan currenttarget cua selectedtarget (Defender) la attackers minh vua click vao
                    if (hit.collider.gameObject.tag == "attackers")
                    {
                        if (selectedTarget.tag == "defenders")
                            selectedTarget.GetComponent<Defender>().currentTarget = hit.collider.gameObject.GetComponent<Attacker>();

                    }
                    //neu doi tuong click khong phai attackers thi currenttarget tro thanh null
                    else
                    {
                        //kiem tra xem doi tuong click co phai la defender hay khong
                        if (selectedTarget.tag == "defenders")
                        {
                            selectedTarget.GetComponent<Defender>().currentTarget = null;
                        }
                    }

                    //di chuyen selectedtarget den vi tri vua click
                    if (canMove)
                        selectedTarget.GetComponent<AgentMoventMent>().SetTargetPosition();
                }


                if (target.gameObject.GetComponents<CircleCollider2D>()[0] == hit.collider || target.gameObject.tag == "attackers")
                {
                    // Luu doi tuong duoc chon
                    selectedTarget = target;
                    // Hien thi thanh máu cua doi tuonng hien tai
                    //ShowHealthBar(selectedTarget);
                    if (selectedTarget != null && selectedTarget.GetComponent<Defender>() != null)
                        selectedTarget.GetComponent<Defender>().selection.GetComponent<SpriteRenderer>().enabled = true;
                }
                //selectedTarget = null;

            }
            //neu khong click vao dau thi van di chuyen
            else if (selectedTarget != null && selectedTarget.tag == "defenders")
            {
                selectedTarget.GetComponent<AgentMoventMent>().SetTargetPosition();
            }

        }



        //an thanh mau
        else if (Input.GetMouseButtonDown(1))
        {
            //HideHealthBar(selectedTarget);
            if (selectedTarget != null && selectedTarget.GetComponent<Defender>() != null)
                selectedTarget.GetComponent<Defender>().selection.GetComponent<SpriteRenderer>().enabled = false;

            selectedTarget = null;
        }

    }

    public void UnClicked()
    {
        if (selectedTarget != null && selectedTarget.GetComponent<AgentMoventMent>() != null)
            selectedTarget.GetComponent<AgentMoventMent>().SetAgentPosition();

        if (selectedTarget != null && selectedTarget.GetComponent<Defender>() != null)
            selectedTarget.GetComponent<Defender>().selection.GetComponent<SpriteRenderer>().enabled = false;

        selectedTarget = null;
    }

    void ShowHealthBar(GameObject target)
    {
        GameObject childGameObject = getGameChildObject(target);
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    void HideHealthBar(GameObject target)
    {
        GameObject childGameObject = getGameChildObject(target);
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }
    GameObject getGameChildObject(GameObject target)
    {
        // lay Transform cua doi tuong cha
        Transform parentTransform = target.transform;
        Transform childTransform = parentTransform.Find("Canvas");
        GameObject childGameObject = childTransform.gameObject;
        return childGameObject;
    }
}
