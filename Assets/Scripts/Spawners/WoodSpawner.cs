using UnityEngine;

namespace Spawners
{
	public class WoodSpawner : MonoBehaviour
	{
		public GameObject woodPrefab;
		public Transform[] spawnPoints;
		public float spawnInterval = 5f;
		private bool _isSpawning = false;

		public void StartSpawning()
		{
			_isSpawning = true;
			InvokeRepeating(nameof(SpawnWood), 1f, spawnInterval);
		}

		public void StopSpawning()
		{
			_isSpawning = false;
			CancelInvoke(nameof(SpawnWood));
		}

		private void SpawnWood()
		{
			if (!_isSpawning) return;

			int randomIndex = Random.Range(0, spawnPoints.Length);
			Instantiate(woodPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
		}
	}
}