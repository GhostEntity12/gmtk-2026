using UnityEngine;

public class InteractionEventSpriteSwap : InteractionEvent
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Sprite newSprite;

	public override void OnTrigger()
	{
		spriteRenderer.sprite = newSprite;
	}
}
