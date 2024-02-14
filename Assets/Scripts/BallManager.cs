using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    #region Singleton
    public static BallManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More Than one BallManager!");
            return;
        }
        instance = this;
    }

    #endregion

    public Rigidbody2D BallMain;

    public List<Ball> balls = new List<Ball>();

    public int CurrentAmountOfBalls;

    public GameObject BallPrefab;

    public float Force;

    Vector3 dir;

    BlockStuck blockStuck;

    Pointer pointer;



    private void Start()
    {
        pointer = GetComponent<Pointer>();
        blockStuck = BlockStuck.instance;
        FillListWithBalls();
    }
    public void LaunchBalls(Vector3 _dir)
    {

        dir = _dir;
        StartCoroutine(TimeBetweenBalls());
    }

    IEnumerator TimeBetweenBalls()
    {
        for (int i = CurrentAmountOfBalls - 1; i >= 0; i--)
        {
            yield return new WaitForFixedUpdate();
            yield return new WaitForFixedUpdate();
            balls[i].LaunchBall(dir * Force);

        }
    }
    public void FillListWithBalls()
    {

        for (int i = 0; i < CurrentAmountOfBalls; i++)
        {
            GameObject ball = Instantiate(BallPrefab);
            balls.Add(ball.GetComponent<Ball>());
            ball.transform.position = BallMain.position;

        }
    }
    public void RemoveBallFromList(Ball ball)
    {
        if (balls.Contains(ball))
        {
            balls.Remove(ball);

        }
        if (balls.Count == 0)
        {
            Debug.Log("Yep");
            FillListWithBalls();
            blockStuck.MoveStuckDown();
            pointer.NextShot();
            Time.timeScale = 1;
        }
    }
}
