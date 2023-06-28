using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHealthBar_Temp : MonoBehaviour
{
    public Canvas canvas;
    // Ví dụ nhân vật đang đánh chọn ( Target )
    void OnMouseDown()
    {
        Debug.Log("In");
        Debug.Log(gameObject.name);
        canvas.enabled = true;
    }
    private void OnMouseExit()
    {
        Debug.Log("Out");
        canvas.enabled = false;
    }
    void Update()
    {
        // Đang lỗi
        if (Input.GetMouseButtonDown(0))
        {
            // lấy được object khi click thì class này để bên ngoài k để trong mỗi game object ( đang lỗi ) 
            //  OnMouseExit() thì vẫn giữ được thanh máu của đối tượng vào click 
            //RaycastHit hit;
            //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) // Lấy đối tượng được click
            //{
            //    // Đang không chạy được vào trong này 
            //    Debug.Log("In");
            //    GameObject target = hit.collider.gameObject; // Lưu đối tượng được click
            //    if (target.CompareTag("Attacker") || target.CompareTag("Defender")) // Kiểm tra nếu là đối tượng tấn công hoặc phòng thủ
            //    {
            //        if (selectedTarget != null && selectedTarget != target) // Kiểm tra nếu đối tượng đã được chọn trước đó và không phải là đối tượng hiện tại
            //        {
            //            HideHealthBar(selectedTarget); // Ẩn thanh máu của đối tượng trước đó
            //        }
            //        selectedTarget = target; // Lưu đối tượng được chọn
            //        ShowHealthBar(selectedTarget); // Hiển thị thanh máu của đối tượng hiện tại
            //    }
            //}
        }
        void ShowHealthBar(GameObject target)
        {
            Debug.Log("Show");
        }

        void HideHealthBar(GameObject target)
        {
            Debug.Log("Hide");
        }
    }
}
