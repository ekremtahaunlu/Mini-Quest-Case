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
        public float moveDistance = 1f;
        public float moveDuration = 0.5f;
        public Animator animator;

        private void Update()
        {
            Vector3 direction = Vector3.zero;
            
            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector3.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector3.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector3.right; 
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector3.back;
            }
            
            if (direction != Vector3.zero)
            {
                Move(direction.normalized);
                animator.SetBool(IsRunning, true);
            }
            else
            {
                animator.SetBool(IsRunning, false);
            }
        }

        private void Move(Vector3 direction)
        {
            Vector3 targetPosition = transform.position + direction * moveDistance;
            
            if (IsWithinFloorBounds(targetPosition))
            {
                transform.DOMove(targetPosition, moveDuration).SetEase(Ease.OutQuad);
            }
        }

        private bool IsWithinFloorBounds(Vector3 targetPosition)
        {
            Collider floorCollider = GameObject.Find("Floor").GetComponent<Collider>();
            
            return floorCollider.bounds.Contains(targetPosition);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Wood"))
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
