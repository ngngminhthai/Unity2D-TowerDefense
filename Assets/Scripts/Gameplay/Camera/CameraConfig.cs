using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfig : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDragging = false;
    private Vector3 lastMousePosition;

    [SerializeField] private float cameraSpeed = 2f;
    [SerializeField] private float leftLimit = -20f;
    [SerializeField] private float rightLimit = 20f;
    [SerializeField] private float bottomLimit = -10f;
    [SerializeField] private float topLimit = 10f;

    void Update()
    {
        // Nếu người chơi bấm chuột trái, bắt đầu kéo màn hình
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Nếu người chơi thả chuột trái, kết thúc kéo màn hình
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Nếu đang kéo màn hình, di chuyển camera theo khoảng cách giữa vị trí chuột hiện tại và vị trí chuột trước đó
        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            transform.position -= new Vector3(deltaMousePosition.x, deltaMousePosition.y, 0) * cameraSpeed * Time.deltaTime;

            // Giới hạn di chuyển của camera
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z
            );

            // Lưu vị trí chuột trước đó để tính khoảng cách di chuyển
            lastMousePosition = Input.mousePosition;
        }
    }
}
