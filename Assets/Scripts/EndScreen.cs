using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
	public enum GameEndReason
	{
		Victory,
		Spotted,
		Time
	}

	[SerializeField] private TextMeshProUGUI scores;
	[SerializeField] private GameObject teacherWinScreen;
	[SerializeField] private GameObject principalLoseScreen;
	[SerializeField] private GameObject studentsLoseScreen;
	[SerializeField] private TextMeshProUGUI rating;

	public void SetEndScreen(GameEndReason reason)
	{

		scores.text = $"Time Remaining.....\r\n..............{ScoreManager.Instance.TimeRemainingFormatted}\r\nChores Complete....\r\n..............{ScoreManager.Instance.ChoresComplete:00}/12";
		switch (reason)
		{
			case GameEndReason.Victory:
				teacherWinScreen.SetActive(true);
				rating.text = ScoreManager.Instance.GetRating();
				break;
			case GameEndReason.Spotted:
				principalLoseScreen.SetActive(true);
				rating.text = "F";
				break;
			case GameEndReason.Time:
				studentsLoseScreen.SetActive(true);
				rating.text = "F";
				break;
			default:
				break;
		}
	}
}
