using UnityEngine;

public class InteractionPointDummySpriteSwap : InteractionPoint
{
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Sprite newSprite;
	public override void Enable()
	{
		spriteRenderer.sprite = newSprite;
	}

	public override string SetPromptVisiblity(bool visible)
	{
		return null;
	}
}
