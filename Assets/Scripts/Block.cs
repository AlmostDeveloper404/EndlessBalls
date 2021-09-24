using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int Health;
    public Text numberText;

    BlockStuck blockStuck;

    public List<GameObject> parts = new List<GameObject>();

    


    private void Start()
    {
        Health = Random.Range(100,30);
        blockStuck = BlockStuck.instance;
        numberText.text = Health.ToString();
    }

    private void Update()
    {
        BlockGRX();
    }

    void BlockGRX()
    {
        int currentParts=0;
        for (int i = 0; i < parts.Count; i++)
        {
            if (Health > i * 20)
            {
                parts[i].SetActive(true);
                currentParts++;
            }
            else
            {
                parts[i].SetActive(false);
            }
        }
        for (int i = 0; i < currentParts; i++)
        {
            parts[i].transform.localPosition = new Vector3(0f,1f*(currentParts-1-i),0f);
        }
        

    }
    public void Damage()
    {
        if (Health==1)
        {
            blockStuck.RemoveFromList(this);
            DestroyBlock();
            return;
        }
        Health--;
        numberText.text = Health.ToString();

    }

    void DestroyBlock()
    {
        Destroy(gameObject);
    }
}
