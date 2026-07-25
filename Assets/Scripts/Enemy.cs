using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public enum Status { Wandering, Chasing }

	[SerializeField] private ViewCone v;
	[SerializeField] private Transform detectTf;
	private float alertness;
	[SerializeField] private float alertnessMax;
	private float alertDecay;
	[SerializeField] private float alertDecayDuration;
	[SerializeField] private Status status;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ProcessAlertness(v.InCone(transform, Vector3.zero));
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
				alertness -= Time.deltaTime;
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
			alertness += Time.deltaTime;
			if (alertness >= alertnessMax)
			{
				GameManager.Instance.EndGame(false);
			}
		}
		return false;
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
