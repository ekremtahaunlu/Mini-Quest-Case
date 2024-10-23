using DG.Tweening;
using Interfaces;
using Managers;
using Photon.Pun;
using UnityEngine;

namespace Players
{
	public class PlayerController : MonoBehaviourPunCallbacks
	{
		private static readonly int IsRunning = Animator.StringToHash("isRunning");
		public Transform targetPosition;
		public Animator animator;

		private void Update()
		{
			if (Input.GetKey(KeyCode.W))
			{
				MoveToTarget();
				animator.SetBool(IsRunning, true);
			}
			else
			{
				animator.SetBool(IsRunning, false);
			}
		}

		private void MoveToTarget()
		{
			transform.DOMove(targetPosition.position, 1f);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag($"Wood"))
			{
				ICollectable collectable = other.GetComponent<ICollectable>();
				if (collectable != null)
				{
					collectable.Collect();
					GameManager gameManager = FindObjectOfType<GameManager>();
					ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

					if (gameManager != null && scoreManager != null)
					{
						scoreManager.AddScore(PhotonNetwork.LocalPlayer, 5);
					}
				}
			}
		}
	}
}