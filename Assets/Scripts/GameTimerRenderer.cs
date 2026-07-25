using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerRenderer : MonoBehaviour
{
	[SerializeField]
	Image clockBackground;
	[SerializeField]
	Image clockHand;
	[SerializeField]
	Image clockFill;

	public void SetFillAmount(float fill)
	{
		clockHand.rectTransform.rotation = Quaternion.Euler(0, 0, fill * 360);
		clockFill.fillAmount = fill;
	}
}
