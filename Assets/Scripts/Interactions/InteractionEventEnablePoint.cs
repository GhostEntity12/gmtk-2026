using UnityEngine;

public class InteractionEventEnablePoint : InteractionEvent
{
	[SerializeField] private InteractionPoint point;

	public override void OnTrigger()
	{
		point.Enable();
	}
}
