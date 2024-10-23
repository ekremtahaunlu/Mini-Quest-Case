using System.Globalization;
using TMPro;
using UnityEngine;

namespace UI
{
	public class UIManager : MonoBehaviour
	{
		public TextMeshProUGUI countdownText;
		public TextMeshProUGUI timerText;
		public TextMeshProUGUI scoreboardText;

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