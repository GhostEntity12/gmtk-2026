using UnityEngine;
using UnityEngine.UI;

public class EnemyDetectionUI : MonoBehaviour
{
	Enemy e;

	[SerializeField] Image fill;

	// Update is called once per frame
	void Update()
	{
		transform.position = e.transform.position + Vector3.back * 1.75f + Vector3.up * 0.01f;
	}

	public void SetFill(float fillAmount)
	{
		//Debug.Log($"Setting fill amount {fillAmount}");
		fill.fillAmount = fillAmount;
	}

	public void SetEnemy(Enemy enemy) => e = enemy;
}
