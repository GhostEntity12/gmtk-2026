using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementFirstPerson : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 movementDelta;
	private Vector3 lookDelta;

	[SerializeField] private Camera playerCamera;

	[SerializeField] private float movementSpeed = 2.5f;
	[SerializeField] private Vector2 lookSpeed = new(15f, 5f);
	[SerializeField] private Vector2 lookSpeedLimit = new(30f, 30f);
	[SerializeField] private Vector2 lookXConstraint = new(-70f, 70f);

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		// Get movement axes from Input class. Clamp to 1.
		Vector3 movementInput = Vector3.ClampMagnitude(new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")), 1);

		// Rotate input to local space
		movementDelta = transform.rotation * movementInput;

		// Get look axes from Input class. Scale and clamp.
		lookDelta = new Vector2(
			Mathf.Clamp(Input.GetAxisRaw("Mouse X") * lookSpeed.x, -lookSpeedLimit.x, lookSpeedLimit.x),
			-Mathf.Clamp(Input.GetAxisRaw("Mouse Y") * lookSpeed.y, -lookSpeedLimit.y, lookSpeedLimit.y)
		);

		// Apply character rotation
		gameObject.transform.rotation = (transform.rotation * Quaternion.Euler(0, lookDelta.x, 0));

		// Apply the targeted rotation
		Vector3 targetRot = new(playerCamera.transform.localRotation.eulerAngles.x + lookDelta.y, 0, 0);
		// Deal with looping
		if (targetRot.x >= 180) targetRot.x -= 360;
		// Clamp values
		targetRot.x = Mathf.Clamp(targetRot.x, lookXConstraint.x, lookXConstraint.y);

		// Apply camera rotation
		playerCamera.transform.localRotation = Quaternion.Euler(targetRot);
	
		// Apply character position
		controller.Move(movementSpeed * Time.deltaTime * movementDelta);
	}
}
