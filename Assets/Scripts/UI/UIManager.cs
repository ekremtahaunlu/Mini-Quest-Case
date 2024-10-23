using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		public Text countdownText;
		public Text timerText;
		public Text scoreboardText;

		public void UpdateCountdown(int countdown)
		{
			countdownText.text = countdown.ToString();
		}

		public void UpdateTimer(float time)
		{
			timerText.text = Mathf.Floor(time).ToString(CultureInfo.InvariantCulture);
		}

		public void ShowScoreboard(string scores)
		{
			scoreboardText.text = scores;
		}
	}
}