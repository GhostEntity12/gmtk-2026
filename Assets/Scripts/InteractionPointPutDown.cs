using UnityEngine;

public class InteractionPointPutDown : InteractionPoint
{
	[SerializeField]
	private string requiredId;

	public override void Interact(PlayerFirstPerson p)
	{
		if (p.hand.id == requiredId)
		{
			// Show item on desk
			p.PutDown(out Holdable h);
			base.Interact(p);
		}
	}
	public override string SetPromptVisiblity(bool visible)
	{
		throw new System.NotImplementedException();
	}
}
