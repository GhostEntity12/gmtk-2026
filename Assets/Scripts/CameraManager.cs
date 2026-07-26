using UnityEngine;

public class CameraManager : MonoBehaviour
{
	[SerializeField] private float cameraDistance = 20;
	// Update is called once per frame
	void Update()
	{
		Camera.main.transform.position = GameManager.Instance.Player.transform.position + Vector3.up * cameraDistance;
	}
}
