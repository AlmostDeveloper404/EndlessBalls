using UnityEngine;


public enum BallState
{
    Idle,
    Active,
    Done
}
public class Pointer : MonoBehaviour
{
    BallManager ballManager;

    public Rigidbody2D BallRigidbody;

    Camera cam;
    Plane plane;
    Vector3 dir;


    public BallState ballState;
    public Prediction prediction;

    private bool _isPressed = false;

    private void Awake()
    {
        ballManager = GetComponent<BallManager>();
        cam = Camera.main;
    }

    private void Start()
    {
        plane = new Plane(-Vector3.forward, Vector3.zero);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            prediction.ShowDots();
            _isPressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            CulculateDirection();
        }
    }

    private void FixedUpdate()
    {

        LinePredictedGRX();

    }

    void LinePredictedGRX()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float distance;
        plane.Raycast(ray, out distance);
        Vector2 pointInPlane = ray.GetPoint(distance);
        dir = (pointInPlane - BallRigidbody.position).normalized;
        prediction.DrawPredictedLine(dir * ballManager.Force);
    }
    void CulculateDirection()
    {
        if (ballState == BallState.Idle)
        {
            ballState = BallState.Active;
            prediction.HideDots();

            ballManager.LaunchBalls(dir);
        }
    }

    public void NextShot()
    {
        _isPressed = false;
        prediction.ShowDots();
        ballState = BallState.Idle;
    }


}
