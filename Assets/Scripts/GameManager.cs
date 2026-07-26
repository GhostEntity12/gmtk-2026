using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public EnemyDetectionUI EnemyUiTemplate { get; private set; }
    [SerializeField] private PlayerTopDown player;

	public GameTimer GameTimer { get; private set; }
    public PlayerTopDown Player => player;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(bool playerWonGame)
    {

    }
}
