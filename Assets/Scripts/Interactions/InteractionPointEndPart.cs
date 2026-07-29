using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPointEndPart : InteractionPoint
{
	[SerializeField] GameTimer gameTimer;
	public override string SetPromptVisiblity(bool visible)
	{
		return null;
	}

	public override void Interact(PlayerFirstPerson p)
	{
		ScoreManager.Instance.SetTimerScore(gameTimer.TimeRemaining);

		SceneManager.LoadScene(2);
	}
}
