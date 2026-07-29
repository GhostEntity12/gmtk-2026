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
			Debug.Log(h.sprite);
			inWorldRenderer.sprite = h.sprite;
			inWorldRenderer.enabled = true;
			base.Interact(p);
		}
		else
		{
			Debug.Log("something not workoing");
		}
	}

	public override string SetPromptVisiblity(bool visible)
	{
		return null;
	}
}
