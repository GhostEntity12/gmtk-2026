using UnityEngine;

public class InteractionPointDummyMaterialChange : InteractionPoint
{
	[SerializeField] private MeshRenderer meshRenderer;
	[SerializeField] private Material newMaterial;
	public override void Enable()
	{
		meshRenderer.material = newMaterial;
	}
	public override string SetPromptVisiblity(bool visible)
	{
		return null;
	}
}
