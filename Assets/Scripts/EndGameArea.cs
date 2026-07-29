using UnityEngine;

public class EndGameArea : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlayerMovementTopDown p))
		{

			GameManager.Instance.EndGame(EndScreen.GameEndReason.Victory);
		}
	}
}
