using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
	PlayerMovementTopDown movement;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake()
	{
		movement = GetComponent<PlayerMovementTopDown>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
