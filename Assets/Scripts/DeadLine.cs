using UnityEngine;
using Main;

public class DeadLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BlockCollision>())
        {
            GameManager.ChangeGameState(GameState.LevelFailed);
        }
    }
}
