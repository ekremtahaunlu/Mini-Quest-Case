using System.Collections;
using System.Globalization;
using Photon.Pun;
using Spawners;
using TMPro;
using UnityEngine;

namespace Managers
{
	public class GameManager : MonoBehaviourPunCallbacks
	{
		public TextMeshProUGUI countdownText;
		public TextMeshProUGUI timerText;
		public GameObject woodPrefab;
		public Transform[] spawnPoints;
		
		[SerializeField] private float gameDuration = 30f;
		private float _remainingTime;

		private bool _gameStarted = false;
		private WoodSpawner _woodSpawner;

		private void Start()
		{
			_remainingTime = gameDuration;
			UpdateTimer(_remainingTime);
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
		
		private IEnumerator GameTimer()
		{
			while (_remainingTime > 0)
			{
				yield return new WaitForSeconds(1f);
				_remainingTime--;
				UpdateTimer(_remainingTime);
			}
			
			EndGame();
		}

		private void StartGame()
		{
			_gameStarted = true;
			PhotonNetwork.CurrentRoom.IsOpen = false;
			_woodSpawner.StartSpawning();
		}

		private void UpdateTimer(float time)
		{
			timerText.text = Mathf.Floor(time).ToString(CultureInfo.InvariantCulture);
		}
		
		private void EndGame()
		{
			Debug.Log("Oyun bitti!");
		}


		private void Update()
		{
			if (_gameStarted)
			{
				
			}
		}
	}
}