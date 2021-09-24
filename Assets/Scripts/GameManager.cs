using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance!=null)
        {
            Debug.LogWarning("More Than one GameManager!");
            return;
        }
        instance = this;
    }

    #endregion

    public GameObject poxyi;

    public GameObject winPanal;
    public GameObject lostPanal;

    public void Win()
    {
        winPanal.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lost()
    {
        lostPanal.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Accelaration(int amount)
    {
        Time.timeScale = amount;
    }

    public void DisplayMassage()
    {
        poxyi.SetActive(true);   
    }
}
