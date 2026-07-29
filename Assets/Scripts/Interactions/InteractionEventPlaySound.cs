using UnityEngine;

public class InteractionEventPlaySound : InteractionEvent
{
	[SerializeField] private AudioSource source;
	[SerializeField] private AudioClip clip;
	[SerializeField] private float volume = 0.8f;

	public override void OnTrigger()
	{
		source.PlayOneShot(clip, volume);
	}
}
