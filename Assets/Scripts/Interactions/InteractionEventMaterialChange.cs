using UnityEngine;

public class InteractionEventMaterialChange : InteractionEvent
{
	[SerializeField] private MeshRenderer meshRenderer;
	[SerializeField] private Material newMaterial;

	public override void OnTrigger()
	{
		meshRenderer.material = newMaterial;
	}
}
