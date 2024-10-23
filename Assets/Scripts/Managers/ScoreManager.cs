using System.Collections.Generic;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Managers
{
	public class ScoreManager : MonoBehaviour
	{
		public TextMeshProUGUI scoreboardText;
		private readonly Dictionary<Player, int> _playerScores = new();

		public void AddScore(Player player, int score)
		{
			if (!_playerScores.TryAdd(player, score))
			{
				_playerScores[player] += score;
			}
		}

		public void ShowScoreboard()
		{
			scoreboardText.text = "Puanlar:\n";
			foreach (var playerScore in _playerScores)
			{
				scoreboardText.text += playerScore.Key.NickName + ": " + playerScore.Value + "\n";
			}
		}
	}
}