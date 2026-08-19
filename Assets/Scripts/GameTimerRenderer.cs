using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerRenderer : MonoBehaviour
{
	[SerializeField] Image clockBackground;
	[SerializeField] Image clockHand;
	[SerializeField] Image clockFill;

	[SerializeField] float maxFill = 0.25f;
	public void SetFillAmount(float fill)
	{
		fill = Mathf.Lerp(0, 0.25f, fill);
		clockHand.rectTransform.rotation = Quaternion.Euler(0, 0, fill * -360);
		clockFill.fillAmount = fill;
	}
}
