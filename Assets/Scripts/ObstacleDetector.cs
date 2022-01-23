using UnityEngine;
using Mirror;
public class ObstacleDetector : NetworkBehaviour
{
    PlayerScript playerScript;
    [SerializeField] float maxSize = 20, incrementAmount = 2;

    private void Awake()
    {
        playerScript = GetComponent<PlayerScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle") && playerScript.isBall)
        {
            print("Collided" + collision.collider.name);
            /*Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.useGravity = true;*/
            Destroy(collision.gameObject);
            this.transform.localScale += new Vector3(incrementAmount, incrementAmount, incrementAmount);
            transform.localScale = Vector3.ClampMagnitude(transform.localScale, maxSize);
            
        }
    }
}
