using UnityEngine;

public class InteractionPointPickup : InteractionPoint
{
	[SerializeField]
	private Holdable item;

	public override void Interact(PlayerFirstPerson p)
	{
		if (p.PickUp(item))
		{
			// Hide item
			base.Interact(p);
		}
	}

	public override string SetPromptVisiblity(bool visible)
	{
		throw new System.NotImplementedException();
	}
}
