using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
	[SerializeField] private ViewCone v;

	[Header("Alertness")]
	private float alertness;
	private float alertDecay;
	[SerializeField] private float alertnessIncreaseRate;
	[SerializeField] private float alertnessDecreaseRate;
	[SerializeField] private float alertDecayDuration;

	[Header("Movement")]
	private NavMeshAgent agent;
	[SerializeField] private Transform[] waypoints;
	private int waypointIndex;
	private Vector3 lastKnownPlayerLocation;


	[Header("Behaviour")]
	[SerializeField] private float alertnessFollowPercentage;
	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ProcessAlertness(v.InCone(transform, GameManager.Instance.Player.transform.position));

		
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="playerInView"></param>
	/// <returns>True if player is </returns>
	bool ProcessAlertness(bool playerInView)
	{
		if (!playerInView) // NEEDS ACTUAL CODE, add raycast for hiding?
		{
			// Player not visible
			// If alertness is at 0, just break here.
			if (alertness <= 0) return true;


			if (alertDecay > 0)
			{
				// Start decreasing the decay timer
				alertDecay -= Time.deltaTime;
			}
			else
			{
				// Decay time has reached zero, start decreasing the alertness
				alertness -= Time.deltaTime * alertnessDecreaseRate;
				if (alertness <= 0)
				{
					return true;
				}
			}
		}
		else
		{
			// Player visible
			// Set decay to max;
			alertDecay = alertDecayDuration;

			// Increase alertness
			alertness += Time.deltaTime * alertnessIncreaseRate;
			if (alertness >= 1)
			{
				GameManager.Instance.EndGame(false);
			}
		}
		return false;
	}

	void ProcessMovement()
	{
		// Recently saw player
		if (alertDecay > 0 && alertness > )
	}

	public bool PlayerInViewCone => v.InCone(transform, new PlayerTopDown().transform.position);

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		// Render behind objects 
		Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
		v.DebugDraw(transform, detectTf.position, 0.5f);
		// Render in front of objects 
		Handles.zTest = UnityEngine.Rendering.CompareFunction.Greater;
		v.DebugDraw(transform, detectTf.position, 0.1f);
	}
#endif
}
