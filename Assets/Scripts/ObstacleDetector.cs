using UnityEngine;
using Mirror;
using Cinemachine;
public class ObstacleDetector : NetworkBehaviour
{
    [SerializeField] float maxSize = 20, incrementAmount = 0.5f;
    CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            print("Collided" + collision.collider.name);
            
            Destroy(collision.gameObject);
            this.transform.localScale += new Vector3(incrementAmount, incrementAmount, incrementAmount);
            transform.localScale = Vector3.ClampMagnitude(transform.localScale, maxSize);
            var c = virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
            c.m_FollowOffset = new Vector3(0, Mathf.Clamp(c.m_FollowOffset.y + incrementAmount, 2, maxSize/2), Mathf.Clamp(c.m_FollowOffset.z - incrementAmount,  -maxSize/2, -3));
        }
    }
}
