using JetBrains.Annotations;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
	private int choresComplete = 0;
	private float timeRemaining = 0;

	public string TimeRemainingFormatted => $"{Mathf.Floor(timeRemaining / 60):00}:{Mathf.Floor(timeRemaining % 60):00}";
	public int ChoresComplete => choresComplete;
	public void SetTimerScore(float timeRemaining)
	{
		this.timeRemaining = timeRemaining;
	}

	public void AddCompletedChores(int chores)
	{
		choresComplete += chores;
	}

	public string GetRating()
	{
		int choreScore = choresComplete switch
		{
			int i when i < 5 => 1,
			int i when i < 9 => 2,
			int i when i < 12 => 3,
			int i when i < 14 => 4,
			_ => 5
		};

		int timeScore = timeRemaining switch
		{
			float i when i > 120 => 1,
			float i when i > 80 => 2,
			float i when i > 30 => 3,
			float i when i > 10 => 4,
			_ => 5
		};

		int totalScore = (choreScore + timeScore) / 2;

		return totalScore switch
		{
			5 => "A+",
			4 => "A",
			3 => "B",
			2 => "C",
			_ => "D"
		};
	}
}
