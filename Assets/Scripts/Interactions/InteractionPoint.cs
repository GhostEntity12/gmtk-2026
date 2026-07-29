using UnityEngine;

public abstract class InteractionPoint : MonoBehaviour
{
	[field: SerializeField] public bool Interactable { get; private set; } = false;

	[SerializeField] private InteractionEvent[] eventsOnComplete;

	[SerializeField] string prompt;

	private void Awake()
	{
		// Set the layer so the raycasts work
		gameObject.layer = 8;
	}

	/// <summary>
	/// Try to interact with this point
	/// </summary>
	/// <param name="p">The player interacting</param>
	public virtual void Interact(PlayerFirstPerson p)
	{
		if (!Interactable) return;

		foreach (InteractionEvent e in eventsOnComplete)
		{
			e.OnTrigger();
		}

		Disable();

		ScoreManager.Instance.AddCompletedChores(1);
	}

	public virtual void Enable() => Interactable = true;

	public virtual void Disable()
	{
		Interactable = false;
		SetPromptVisiblity(false);
	}

	public virtual void SetPromptVisiblity(bool visible)
	{

	}
}
