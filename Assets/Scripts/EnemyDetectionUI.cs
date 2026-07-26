using UnityEngine;
using UnityEngine.UI;

public class EnemyDetectionUI : MonoBehaviour
{
	Enemy e;

	[SerializeField] Image fill;

	// Update is called once per frame
	void Update()
	{
		transform.position = e.transform.position;
	}

	public void SetFill(float fillAmount) => fill.fillAmount = fillAmount;
	
	public void SetEnemy(Enemy enemy) => e = enemy;
}
