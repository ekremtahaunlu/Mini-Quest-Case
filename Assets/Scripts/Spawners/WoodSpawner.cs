using System.Collections;
using UnityEngine;

namespace Spawners
{
	public class WoodSpawner : MonoBehaviour
	{
		public GameObject woodPrefab;
		public Transform[] spawnPoints;
		public int numberOfWoodsToSpawn = 10;

		public void StartSpawning()
		{
			StartCoroutine(SpawnWood());
		}

		private IEnumerator SpawnWood()
		{
			for (int i = 0; i < numberOfWoodsToSpawn; i++)
			{
				int randomIndex = Random.Range(0, spawnPoints.Length);
				Transform spawnPoint = spawnPoints[randomIndex];
				
				Instantiate(woodPrefab, spawnPoint.position, spawnPoint.rotation);
				
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}