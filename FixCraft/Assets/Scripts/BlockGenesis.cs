using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenesis : MonoBehaviour
{
    [Range(30,100)]
    [SerializeField]  private int blockFieldSize = 10;
    [SerializeField] public List<GameObject> spawnedTiles;

    Vector2 blockSize;
    [SerializeField] GameObject[] blocks;
    
    void Start()
    {
        float   _curWidth = 0, 
                _curHeight = 0;

        float step = (blocks[0].GetComponent<SpriteRenderer>()) ? blocks[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x : 0.32f;
        step *= 0.99f;

        int spaceCount = 0;
        int startBlock = (blockFieldSize * blockFieldSize) / 4 ;
        int endBlock = (blockFieldSize * blockFieldSize) - startBlock;
        for (int i = 0; i < blockFieldSize * blockFieldSize; i++)
        {
            
            //Here we can use a pool instead of a straight up instantiate (rough on performance)
            GameObject curBlock = GameObject.Instantiate(blocks[Random.Range(0, blocks.Length)]);
            curBlock.transform.position = new Vector2(_curWidth, _curHeight);

            //Spawn-Space 
            if (i > startBlock && i < endBlock &&_curWidth > (blockFieldSize * 0.32f * 0.25f) && _curWidth < (blockFieldSize * 0.32f * 0.75f) && spaceCount < (20 * 20))
            {
                //Replace with ground-walk game object from list instead of null. Testing only
                Debug.Log("Fired on " + i + "CurWidth: " + _curWidth);
                curBlock.GetComponent<SpriteRenderer>().sprite = null;
                spaceCount++;
            }
            _curWidth += step;
            if (i != 1 && i % blockFieldSize == blockFieldSize-1 )
            {
                _curWidth = 0;
                _curHeight+= step;
            }
            spawnedTiles.Add(curBlock);
        }
    }
}
