using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenesis : MonoBehaviour
{
    [Range(30,100)]
    [SerializeField] private int blockFieldSize = 40;
    [SerializeField] public List<GameObject> spawnedTiles;
    [SerializeField] GameObject[] blocks, groundBlocks;
     
    void Start()
    {
        float   _curWidth = 0, 
                _curHeight = 0;

        float   _step = (blocks[0].GetComponent<SpriteRenderer>()) ? blocks[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x : 0.32f, 
                step = _step;


        int spaceCount = 0;
        int startBlock = ((blockFieldSize * blockFieldSize) / 3)  ;
        int endBlock = (blockFieldSize * blockFieldSize) - startBlock;
        bool spaceTrigger = false;
        float trigReset = 0;

        for (int i = 0; i < blockFieldSize * blockFieldSize; i++)
        {
            //Here we can use a pool instead of a straight up instantiate (rough on performance)
            GameObject curBlock = GameObject.Instantiate(blocks[Random.Range(0, blocks.Length)]);
           // GameObject undrBlock = GameObject.Instantiate(groundBlocks[Random.Range(0, groundBlocks.Length)]);
            curBlock.transform.position = new Vector2(_curWidth, _curHeight);
            //undrBlock.transform.position = new Vector2(_curWidth, _curHeight);

            _curWidth += step;

            if (i != 1 && i % blockFieldSize == blockFieldSize-1 )
            {
                _curWidth = 0;
                _curHeight+= step;
            }

            spawnedTiles.Add(curBlock);

            if (spaceCount != 0 && spaceCount % 20 == 0)
            {
                spaceTrigger = true;
                trigReset = _curHeight;
                spaceCount++;
            }

            if (spaceTrigger)
            {
                if (_curHeight != trigReset)
                {
                    spaceTrigger = false;
                    trigReset = 0;
                }
            }
            //Spawn-Space 
            if (i >= startBlock && i < endBlock && _curWidth >= ( blockFieldSize * _step ) * 0.33f  && _curWidth < (blockFieldSize * _step) * 0.66f && spaceCount <= (20 * 20) && !spaceTrigger)
            {
                //Testing only
                //Debug.Log("fired");
                Destroy(curBlock);
                spaceCount++;
            }

            
        }
    }
}
