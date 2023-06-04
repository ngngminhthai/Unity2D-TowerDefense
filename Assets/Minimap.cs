using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minimap : MonoBehaviour, IDragHandler
{

	private bool isDragging = false;
	private Vector3 lastMousePosition;

	[SerializeField] private float cameraSpeed = 20f;
	[SerializeField] private float leftLimit = -40f;
	[SerializeField] private float rightLimit = 40f;
	[SerializeField] private float bottomLimit = -40f;
	[SerializeField] private float topLimit = 40f;
	public Camera camera;

	public void OnDrag(PointerEventData eventData)
	{

		Vector2 dragDelta = eventData.delta;
		camera.transform.position -= new Vector3(dragDelta.x, dragDelta.y, 0) * cameraSpeed * Time.deltaTime;

		camera.transform.position = new Vector3(
			Mathf.Clamp(camera.transform.position.x, leftLimit, rightLimit),
			Mathf.Clamp(camera.transform.position.y, bottomLimit, topLimit),
			camera.transform.position.z
		);

		Debug.Log(camera.transform.position);
	}



	//public void OnUpdateSelected(BaseEventData eventData)
	//{
	//	Debug.Log("DRUG" + Input.mousePosition);
	//	// Nếu người chơi bấm chuột trái, bắt đầu kéo màn hình
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		isDragging = true;
	//		lastMousePosition = Input.mousePosition;
	//	}

	//	// Nếu người chơi thả chuột trái, kết thúc kéo màn hình
	//	if (Input.GetMouseButtonUp(0))
	//	{
	//		isDragging = false;
	//	}

	//	// Nếu đang kéo màn hình, di chuyển camera theo khoảng cách giữa vị trí chuột hiện tại và vị trí chuột trước đó
	//	if (isDragging)
	//	{
	//		Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
	//		camera.transform.position -= new Vector3(deltaMousePosition.x, deltaMousePosition.y, 0) * cameraSpeed * Time.deltaTime;

	//		// Giới hạn di chuyển của camera
	//		camera.transform.position = new Vector3(
	//			Mathf.Clamp(camera.transform.position.x, leftLimit, rightLimit),
	//			Mathf.Clamp(camera.transform.position.y, bottomLimit, topLimit),
	//			camera.transform.position.z
	//		);

	//		// Lưu vị trí chuột trước đó để tính khoảng cách di chuyển
	//		lastMousePosition = Input.mousePosition;
	//	}
	//}
}