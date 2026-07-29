using UnityEngine;
using UnityEngine.UI;

public class PlayerFirstPerson : MonoBehaviour
{
	public Holdable Hand { get; private set; } = new Holdable();
	[SerializeField] private Image handRenderer;
	[SerializeField] private Image heldItemRenderer;

	[SerializeField] private float interactRange = 1f;
	[SerializeField] private float interactRadius = 0.4f;


	[SerializeField] Color debugNeutral;
	[SerializeField] Color debugPressed;
	[SerializeField] Color debugInRange;

	private void Start()
	{
		Hand.Reset();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TryInteract();
		}
	}

	private void TryInteract()
	{
		// Get the interactionPoint
		Collider[] interactable = new Collider[4];
		Physics.OverlapSphereNonAlloc(Camera.main.transform.position + Camera.main.transform.forward * interactRange, interactRadius, interactable, 1 << 8);

		foreach (Collider InteractObject in interactable)
		{
			// Try to interact
			if (InteractObject != null && InteractObject.TryGetComponent(out InteractionPoint p) && p.Interactable)
			{
				p.Interact(this);
			}
		}
	}

	/// <summary>
	/// Pivk up an item
	/// </summary>
	/// <param name="h">The holdable being picked up</param>
	/// <returns>True if the holdable was picked up</returns>
	public bool PickUp(Holdable h)
	{
		if (Hand.id != string.Empty)
		{
			// Hand already full
			Debug.LogError("Hand already holding item");
			return false;
		}

		// Disable the interactable so it can't be interacted with again
		Hand = h;
		heldItemRenderer.sprite = h.sprite;
		heldItemRenderer.enabled = true;
		handRenderer.enabled = false;
		return true;
	}

	/// <summary>
	/// Put down an item
	/// </summary>
	/// <param name="h">The holdable the player put down</param>
	/// <returns>True if the holdable was placed down</returns>
	public bool PutDown(out Holdable h)
	{
		if (Hand == null)
		{
			// Hand is empty
			Debug.LogError("Hand not holding item");
			h = null;
			return false;
		}

		h = new(Hand);
		Hand.Reset();
		heldItemRenderer.sprite = null;
		heldItemRenderer.enabled = false;
		handRenderer.enabled = true;
		return true;

	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Physics.CheckSphere(Camera.main.transform.position + Camera.main.transform.forward * interactRange, interactRadius, 1 << 8) ? debugInRange : Input.GetKey(KeyCode.Space) ? debugPressed : debugNeutral;
		Gizmos.DrawSphere(Camera.main.transform.position + Camera.main.transform.forward * interactRange, interactRadius);
	}
}
