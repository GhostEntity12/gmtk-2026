using UnityEngine;

/// <summary>
/// Does nothing. Calls Enable() on the referenced InteractionPoints after a delay.
/// </summary>
public class InteractionPointDelay : InteractionPoint
{
	[SerializeField] private float delayDuration;
	
	private float timer;
	private bool doTimer = false;
	private bool timerComplete = false;
	
	public override string SetPromptVisiblity(bool visible)
	{
		throw new System.NotImplementedException();
	}

	public override void Enable()
	{
		// Usually, this would set this to be interactable.
		// Here, we just start the timer instead.
		// To ensure that this can't eb tirggered multiple times by mistake,
		// check the timerComplete flag.
		if (timerComplete) return;

		doTimer = true;
		timer = delayDuration;
	}

	private void Update()
	{
		if (doTimer && !timerComplete)
		{
			// Increment timer
			timer -= Time.deltaTime;
			if (timer < 0)
			{
				// Time is up
				doTimer = false;
				timerComplete = true;
				// Enable so the Interact() doesn't fail
				base.Enable();
				// Call base.Interact to Enable() the referenced points.
				// Since this should never need player reference, null is okay.
				// A bit of a hack since this could, foe example, trigger PutDown
				// events incorrectly.
				base.Interact(null);
			}
		}
	}
}
