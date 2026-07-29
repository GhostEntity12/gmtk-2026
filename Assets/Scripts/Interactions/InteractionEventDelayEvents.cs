using UnityEngine;

public class InteractionEventDelayEvents : InteractionEvent
{
	private enum EventStatus { Idle, InProgress, Complete }

	[SerializeField] private float delayDuration;
	[SerializeField] private InteractionEvent[] delayedEvents;

	private float timer;
	private EventStatus status = EventStatus.Idle;

	public override void OnTrigger()
	{
		// Only allow to trigger if currently in idle
		if (status != EventStatus.Idle) return;

		status = EventStatus.InProgress;
		timer = delayDuration;
	}

	private void Update()
	{
		if (status != EventStatus.InProgress) 
			return;
	
		// Timer in progress
		// Decrement timer
		timer -= Time.deltaTime;

		// Timer up
		if (timer >= 0) 
			return;
		
		// Call OnTrigger for all child events
		foreach (InteractionEvent e in delayedEvents)
		{
			e.OnTrigger();
		}

		// Mark as finished
		status = EventStatus.Complete;
	}
}
