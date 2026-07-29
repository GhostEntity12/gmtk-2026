using UnityEngine;

public class InteractionPointPickup : InteractionPoint
{
	[SerializeField] private Holdable item;
	[SerializeField] private SpriteRenderer inWorldRenderer;

	public override void Interact(PlayerFirstPerson p)
	{
		if (p.PickUp(item))
		{
			inWorldRenderer.sprite = null;
			base.Interact(p);
		}
	}
}
