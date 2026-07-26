using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

	[Header("Alertness")]
	private float alertness;
	private float alertDecay;
	[SerializeField] private float alertnessIncreaseRate;
	[SerializeField] private float alertnessDecreaseRate;
	[SerializeField] private float alertDecayDuration;

	[Header("Movement")]
	private NavMeshAgent agent;
	private int waypointIndex;
	private Vector3 lastKnownPlayerLocation;
	[SerializeField] private Transform[] waypoints;


	[Header("Behaviour")]
	[SerializeField, Range(0, 1)] private float alertnessFollowPercentage;
	[SerializeField, Range(0, 1)] private float alertnessCuriousPercentage;
	private bool isChasing;

	[Header("Debug")]
	[SerializeField] private Transform testCollision;

	[Header("Viewcones")]
	[SerializeField] private ViewCone[] viewcones;
	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		waypointIndex = GetNearestWaypoint();
		agent.SetDestination(waypoints[waypointIndex].position);
	}

	// Update is called once per frame
	void Update()
	{
		ProcessAlertness(CheckPlayerVisible());
		ProcessMovement();
	}

	bool CheckPlayerVisible()
	{
		foreach (ViewCone vc in viewcones)
		{
			// In cone, successful raycast and has component
			if (vc.InCone(transform, GameManager.Instance.Player.transform.position) &&
				Physics.Raycast(transform.position, GameManager.Instance.Player.transform.position - transform.position, out RaycastHit hit, vc.length)
				&& hit.transform.TryGetComponent(out PlayerTopDown p))
			{
				// Player in line of sight
				Debug.Log("PLAYER IN VIEW!!");
				return true;
			}
		}
		return false;
	}

	void ProcessAlertness(bool playerInView)
	{
		if (playerInView)
		{
			// Player visible
			// Set decay to max;
			alertDecay = alertDecayDuration;
			// Mark last known location
			lastKnownPlayerLocation = GameManager.Instance.Player.transform.position;
			// Increase alertness
			alertness += Time.deltaTime * alertnessIncreaseRate;
			if (alertness >= 1)
			{
				GameManager.Instance.EndGame(false);
			}
		}
		else
		{
			// Player not visible
			if (alertDecay > 0)
			{
				// Start decreasing the decay timer
				alertDecay -= Time.deltaTime;
			}
			else if (alertness > 0)
			{
				// Decay time has reached zero, start decreasing the alertness
				alertness -= Time.deltaTime * alertnessDecreaseRate;
			}
			else
			{
				// alertness at zero
				// Forget player location
				lastKnownPlayerLocation = Vector3.negativeInfinity;
			}
		}
	}

	void ProcessMovement()
	{
		if (alertDecay > 0 && lastKnownPlayerLocation != Vector3.negativeInfinity)// && alertness > alertnessFollowPercentage)
		{
			//switch (alertness)
			//{
			//	case float i when i > alertnessFollowPercentage:
			//		break;
			//	case float i when i > alertnessCuriousPercentage:
			//		break;
			//	default:
			//		break;
			//}
			//// Can currently see player
			//// Recently saw player
			//if (alertness > alertnessFollowPercentage)
			//{
			//}

			// Move to last known player position
			// Only update if the last know location has changed
			if (agent.destination != lastKnownPlayerLocation)
			{
				agent.SetDestination(lastKnownPlayerLocation);
				// Just to ensure the position isn't off the navmesh
				lastKnownPlayerLocation = agent.destination;
			}
		}
		else
		{
			if (isChasing)
			{
				// Was chasing player last frame
				// Change destination to closest waypoint
				waypointIndex = GetNearestWaypoint();
				agent.SetDestination(waypoints[waypointIndex].position);
				isChasing = false;
			}
			else
			{
				if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) <= agent.stoppingDistance)
				{
					// Increment waypoint path
					waypointIndex = (waypointIndex + 1) % waypoints.Length;
					agent.SetDestination(waypoints[waypointIndex].position);
				}
			}
		}


	}

	int GetNearestWaypoint()
	{
		float shortestDistance = Mathf.Infinity;
		int shortestIndex = -1;
		NavMeshPath path = new();

		for (int i = 0; i < waypoints.Length; i++)
		{
			// Calculate the path to the point
			NavMesh.CalculatePath(transform.position, waypoints[i].position, NavMesh.AllAreas, path);

			// Calculate the path length
			float distance = 0;
			for (int j = 0; j < path.corners.Length - 1; j++)
			{
				distance += Vector3.Distance(path.corners[j], path.corners[j + 1]);
			}
			// Compare to the current shortest path
			if (distance < shortestDistance)
			{
				// Point is closer
				shortestDistance = distance;
				shortestIndex = i;
			}
		}
		return shortestIndex;
	}

#if UNITY_EDITOR
	private void OnDrawGizmos()
	{
		// Render viewcone
		if (testCollision)
		{
			foreach (ViewCone vc in viewcones)
			{
				// Render behind objects 
				Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
				vc.DebugDraw(transform, testCollision.transform.position, 0.5f);
				// Render in front of objects 
				Handles.zTest = UnityEngine.Rendering.CompareFunction.Greater;
				vc.DebugDraw(transform, testCollision.transform.position, 0.1f);
			}
		}

		// Render waypoint path
		Gizmos.color = Color.yellow;
		for (int i = 0; i < waypoints.Length; i++)
		{
			Gizmos.DrawLine(waypoints[i].position, waypoints[(i + 1) % waypoints.Length].position);
		}

		//Render current path
		if (agent)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(transform.position, agent.destination);
		}
	}
#endif
}
