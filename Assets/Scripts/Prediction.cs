using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prediction : MonoBehaviour
{
    public GameObject BallToCopy;
    public GameObject PredictedPointPrefab;
    public GameObject LevelBuild;

    GameObject predictedPointGO;
    GameObject ballPhisicsCopy;

    PhysicsScene2D physicsScene;

    public List<GameObject> points = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < 80; i++)
        {
            predictedPointGO=Instantiate(PredictedPointPrefab,transform);
            points.Add(predictedPointGO);
        }

        Scene predictionScene= SceneManager.CreateScene("Prediction",new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        physicsScene = predictionScene.GetPhysicsScene2D();

        ballPhisicsCopy= Instantiate(BallToCopy);
        ballPhisicsCopy.GetComponent<Rigidbody2D>().isKinematic = false;
        ballPhisicsCopy.GetComponent<Renderer>().enabled = false;

        GameObject predictedSceneGO = Instantiate(LevelBuild);
        Renderer[] renderers = predictedSceneGO.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
        

        SceneManager.MoveGameObjectToScene(ballPhisicsCopy,predictionScene);
        SceneManager.MoveGameObjectToScene(predictedSceneGO, predictionScene);
    }
    public void DrawPredictedLine(Vector3 velocity)
    {
        ballPhisicsCopy.transform.position = BallToCopy.transform.position;
        ballPhisicsCopy.transform.rotation = BallToCopy.transform.rotation;
        ballPhisicsCopy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ballPhisicsCopy.GetComponent<Rigidbody2D>().angularVelocity = 0;

        ballPhisicsCopy.GetComponent<Rigidbody2D>().velocity = velocity;


        for (int i = 0; i < points.Count; i++)
        {
            physicsScene.Simulate(Time.fixedDeltaTime);
            
            points[i].transform.position = ballPhisicsCopy.transform.position;
        }
    }

    public void HideDots()
    {
        gameObject.SetActive(false);
    }

    public void ShowDots()
    {
        gameObject.SetActive(true);
    }

    
}
