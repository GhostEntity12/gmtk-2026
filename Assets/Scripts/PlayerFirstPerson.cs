using UnityEngine;
using UnityEngine.UI;

public class PlayerFirstPerson : MonoBehaviour
{
	public Holdable hand { get; private set; }
	[SerializeField]
	private SpriteRenderer handRenderer;
	[SerializeField]
	private SpriteRenderer heldItemRenderer;

	/// <summary>
	/// Pivk up an item
	/// </summary>
	/// <param name="h">The holdable being picked up</param>
	/// <returns>True if the holdable was picked up</returns>
	public bool PickUp(Holdable h)
	{
		if (hand != null)
		{
			// Hand already full
			Debug.LogError("Hand already holding item");
			return false;
		}

		// Disable the interactable so it can't be interacted with again
		hand = h;
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
		if (hand == null)
		{
			// Hand is empty
			Debug.LogError("Hand not holding item");
			h = null;
			return false;
		}

		h = hand;
		hand = null;
		heldItemRenderer.sprite = null;
		heldItemRenderer.enabled = false;
		handRenderer.enabled = true;
		return true;

	}
}
