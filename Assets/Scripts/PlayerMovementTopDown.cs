using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;
	[SerializeField]
	private float rotSpeed = 90;
    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
	void Awake()
    {
        controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		// Get input
		Vector3 rawInput = new(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		
		// Scale input
		Vector3 movementInput = movementSpeed * Time.deltaTime * Vector3.ClampMagnitude(rawInput, 1);
		controller.Move(movementInput);

		// Only update rotation if the player is moving
		if (rawInput != Vector3.zero)
		{
			Quaternion targetRotation = Quaternion.Euler(0, Mathf.Atan2(rawInput.x, rawInput.z) * (180 / Mathf.PI), 0);
			gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
		}
	}
}
