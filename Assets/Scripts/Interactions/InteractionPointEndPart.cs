using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPointEndPart : InteractionPoint
{
	[SerializeField] GameTimer gameTimer;

	public override void Interact(PlayerFirstPerson p)
	{
		// Store the game time for scene transfer
		ScoreManager.Instance.SetTimerScore(gameTimer.TimeRemaining);

		SceneManager.LoadScene(2);
	}
}
