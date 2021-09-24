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

    private void Awake()
    {
        ballManager = GetComponent<BallManager>();
        cam = Camera.main;
    }

    private void Start()
    {
        plane = new Plane(-Vector3.forward,Vector3.zero);
    }

    private void Update()
    {
        CulculateDirection();
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
            if (Input.GetMouseButtonDown(0))
            {
                ballState = BallState.Active;
                prediction.HideDots();

                ballManager.LaunchBalls(dir);
            }
        }        
    }

    public void NextShot()
    {
        prediction.ShowDots();
        ballState = BallState.Idle;
    }

    
}
