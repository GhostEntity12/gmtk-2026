using UnityEngine;

public class GameTimer : MonoBehaviour
{
	[SerializeField] private float gameDuration;
	[SerializeField] private float remainingGameTime;

	[SerializeField] private GameTimerRenderer gtr;

	private bool timerActive = false;
	public float TimeRemaining => remainingGameTime;

	private void Start()
	{
		ScoreManager s = (ScoreManager)FindAnyObjectByType(typeof(ScoreManager));
		if (s != null && s.TimeRemaining != float.NegativeInfinity)
		{
			remainingGameTime = s.TimeRemaining;
		}
		else
		{
			ResetTimer();
		}
		SetTimerStatus(true);
	}

	// Update is called once per frame
	void Update()
	{
		if (!timerActive) return;

		if (!UpdateTimer()) return;

		// End game
		SetTimerStatus(false);
		GameManager.Instance.EndGame(EndScreen.GameEndReason.Time);
	}

	public void SetTimerStatus(bool active) => timerActive = active;

	/// <summary>
	/// Resets the timer
	/// </summary>
	/// <param name="pauseOnReset">Whether the timer should pause on reset</param>
	public void ResetTimer(bool pauseOnReset = true)
	{
		remainingGameTime = gameDuration;

		if (pauseOnReset)
		{
			timerActive = false;
		}
	}

	/// <summary>
	/// Updates the timer
	/// </summary>
	/// <returns>True if the timer has run out</returns>
	bool UpdateTimer()
	{
		remainingGameTime -= Time.deltaTime;
		gtr.SetFillAmount(remainingGameTime);
		return remainingGameTime < 0;
	}
}
