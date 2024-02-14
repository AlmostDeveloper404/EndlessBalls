using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class BlockStuck : MonoBehaviour
{

    #region Singleton
    public static BlockStuck instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one BlockStuck!");
            return;
        }
        instance = this;
    }

    #endregion

    public List<Block> blocks = new List<Block>();
    public Transform BlockStuckTransform;

    public int moveDownDistance = 2;

    public void RemoveFromList(Block block)
    {
        if (blocks.Count == 1)
        {
            GameManager.ChangeGameState(GameState.LevelCompleted);
        }
        blocks.Remove(block);
    }

    public void MoveStuckDown()
    {
        BlockStuckTransform.position += new Vector3(0f, -moveDownDistance, 0f);
    }
}
