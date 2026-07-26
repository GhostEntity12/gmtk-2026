using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = GameManager.Instance.Player.transform.position + Vector3.up * 15;
    }
}
