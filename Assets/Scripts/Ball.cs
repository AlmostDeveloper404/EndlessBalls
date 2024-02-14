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

    private void OnTriggerEnter2D(Collider2D other)
    {
        DeadLine deadLine = other.GetComponent<DeadLine>();

        if (deadLine)
        {
            Debug.Log("Yep");
            ballManager.RemoveBallFromList(this);
            Destroy(gameObject);
        }
    }
}
