using UnityEngine;

public class Ball : MonoBehaviour
{

    BallManager ballManager;

    Rigidbody2D ballRB;

    private void Start()
    {
        ballManager = BallManager.instance;
        ballRB = GetComponent<Rigidbody2D>();
    }

    public void LaunchBall(Vector3 dir)
    {
        ballRB.velocity = dir;
        ballRB.isKinematic = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("DeathLine"))
        {
            ballManager.RemoveBallFromList(this);
            Destroy(gameObject);
        }
    }
}
