using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[field: SerializeField] public EnemyDetectionUI EnemyUiTemplate { get; private set; }
    [SerializeField] private GameTimer gameTimer;
    [SerializeField] private PlayerTopDown player;
    [SerializeField] private EndScreen endScreen;
    public PlayerTopDown Player => player;

	public GameTimer GameTimer => gameTimer;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        // Import timer status
        gameTimer.ResetTimer(false);
        gameTimer.SetTimerStatus(true);
    }

    public void EndGame(EndScreen.GameEndReason reason)
    {
        Debug.Log("Game ended");
        ScoreManager.Instance.SetTimerScore(gameTimer.TimeRemaining);
        endScreen.SetEndScreen(reason);   
    }
}
