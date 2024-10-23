using System.Collections;
using Photon.Pun;
using Spawners;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
	public class GameManager : MonoBehaviourPunCallbacks
	{
		public Text countdownText;
		public Text timerText;
		public GameObject woodPrefab;
		public Transform[] spawnPoints;

		private bool _gameStarted = false;
		private WoodSpawner _woodSpawner;

		private void Start()
		{
			_woodSpawner = GetComponent<WoodSpawner>();

			if (PhotonNetwork.IsMasterClient)
			{
				StartCoroutine(StartGameCountdown());
			}
		}

		private IEnumerator StartGameCountdown()
		{
			int countdown = 3;
			while (countdown > 0)
			{
				countdownText.text = countdown.ToString();
				yield return new WaitForSeconds(1);
				countdown--;
			}
			StartGame();
		}

		private void StartGame()
		{
			_gameStarted = true;
			PhotonNetwork.CurrentRoom.IsOpen = false;
			_woodSpawner.StartSpawning();
		}

		private void Update()
		{
			if (_gameStarted)
			{
				
			}
		}
	}
}