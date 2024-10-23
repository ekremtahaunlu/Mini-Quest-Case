using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
	public class ScoreManager : MonoBehaviour
	{
		public Text scoreboardText;
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