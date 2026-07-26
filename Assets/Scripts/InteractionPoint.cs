using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionPoint : MonoBehaviour
{
	[field: SerializeField] public bool Interactable { get; private set; } = false;

	[SerializeField] private List<InteractionPoint> newInteractionsOnComplete;

	[SerializeField] string prompt;

	private void Awake()
	{
		gameObject.layer = 8;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="p"></param>
	/// <returns>True on a successful interaction</returns>
	public virtual void Interact(PlayerFirstPerson p)
	{
		if (!Interactable) return;

		foreach (InteractionPoint interaction in newInteractionsOnComplete)
		{
			interaction.Enable();
		}
		Debug.Log($"Interacted with {gameObject.name}");
		Disable();
	}

	public virtual void Enable() => Interactable = true;

	public virtual void Disable()
	{
		Interactable = false;
		SetPromptVisiblity(false);
	}

	public abstract string SetPromptVisiblity(bool visible);
}
