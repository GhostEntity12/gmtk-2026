using UnityEngine;

public class InteractionPointPickup : InteractionPoint
{
	[SerializeField] private Holdable item;
	[SerializeField] private SpriteRenderer inWorldRenderer;

	public override void Interact(PlayerFirstPerson p)
	{
		if (p.PickUp(item))
		{
			inWorldRenderer.enabled = false;
			base.Interact(p);
		}
	}

	public override string SetPromptVisiblity(bool visible)
	{
		return null;
	}
}
