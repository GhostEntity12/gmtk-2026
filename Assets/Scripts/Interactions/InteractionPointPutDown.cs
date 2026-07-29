using UnityEngine;

public class InteractionPointPutDown : InteractionPoint
{
	[SerializeField] private string requiredId;
	[SerializeField] private SpriteRenderer inWorldRenderer;

	public override void Interact(PlayerFirstPerson p)
	{
		if (p.Hand.id == requiredId)
		{
			p.PutDown(out Holdable h);
			inWorldRenderer.sprite = h.sprite;
			base.Interact(p);
		}
	}
}
