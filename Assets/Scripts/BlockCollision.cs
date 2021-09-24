using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    Block block;
    void Start()
    {
        block = GetComponentInParent<Block>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ball>())
        {
            block.Damage();
        }
    }
}
