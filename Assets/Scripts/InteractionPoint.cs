using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionPoint : MonoBehaviour
{
	[field: SerializeField]
	public bool Interactable { get; private set; } = false;

	[SerializeField]
	private List<InteractionPoint> newInteractionsOnComplete;

	[SerializeField]
	string prompt;

	public virtual void Interact(PlayerFirstPerson p)
	{
		if (!Interactable) return;

		foreach (InteractionPoint interaction in newInteractionsOnComplete)
		{
			interaction.Enable();
		}

		Disable();
	}

	public void Enable() => Interactable = true;

	public void Disable()
	{
		Interactable = false;
		SetPromptVisiblity(false);
	}

	public abstract string SetPromptVisiblity(bool visible);
}
