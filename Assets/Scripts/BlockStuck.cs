using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main;

public class BlockStuck : MonoBehaviour
{

    #region Singleton
    public static BlockStuck instance;



    #endregion

    private List<Block> _blocks = new List<Block>();
    public Transform BlockStuckTransform;

    public int moveDownDistance = 2;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Block block = transform.GetChild(i).GetComponent<Block>();
            if (block)
            {
                _blocks.Add(block);
            }
        }

        if (instance != null)
        {
            Debug.LogWarning("More than one BlockStuck!");
            return;
        }
        instance = this;
    }

    public void RemoveFromList(Block block)
    {
        if (_blocks.Count == 1)
        {
            GameManager.ChangeGameState(GameState.LevelCompleted);
        }
        _blocks.Remove(block);
    }

    public void MoveStuckDown()
    {
        BlockStuckTransform.position += new Vector3(0f, -moveDownDistance, 0f);
    }
}
