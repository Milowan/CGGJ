using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenesis : MonoBehaviour
{
    [Range(100, 1000)]
    [SerializeField] private int blockFieldSize = 40;
    [SerializeField] public List<GameObject> spawnedTiles;
    [SerializeField] GameObject[] blocks;
    [Space(15)]
    [SerializeField] GameObject charSpawnObject, gemBaby;
    [SerializeField] Grid sandGrid;

    private bool spawnPlaced = false;

    void Start()
    {
        float _curWidth = 0,
                _curHeight = 0;

        float _step = (blocks[0].GetComponent<SpriteRenderer>()) ? blocks[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x : 0.32f,
                step = _step;

        int spaceCount = 0;
        int startBlock = ((blockFieldSize * blockFieldSize) / 3);
        int endBlock = (blockFieldSize * blockFieldSize) - startBlock;
        bool spaceTrigger = false;
        float trigReset = 0;

        for (int i = 0; i < blockFieldSize * blockFieldSize; i++)
        {
            //Having fun
            System.Func<GameObject> lambdaObject = () =>
            {
                float wid = (blockFieldSize * _step);
                //bedrock outline
                if (_curWidth < wid * 0.03f || _curHeight < wid * 0.03f || _curWidth > wid * 0.97f || _curHeight > wid * 0.97f)
                {
                    return blocks[0];
                }
                //steel
                else if (_curWidth < wid * 0.1f || _curHeight < wid * 0.1f || _curWidth > wid * 0.9f || _curHeight > wid * 0.9f)
                {
                    if (_curWidth > wid * 0.09f && _curWidth < wid * 0.99f || _curHeight > wid * 0.09f && _curHeight < wid * 0.99f)
                    {
                        return blocks[Random.Range(1, 3)];
                    }
                    else
                        return blocks[1];
                }
                //stone
                else if (_curWidth < wid * 0.2f || _curHeight < wid * 0.2f || _curWidth > wid * 0.8f || _curHeight > wid * 0.8f)
                {
                    if (_curWidth > wid * 0.1f && _curWidth < wid * 0.9f || _curHeight > wid * 0.9f && _curHeight < wid * 0.17f)
                    {
                        if (Random.Range(0f,100f) > 75)
                        {
                            return blocks[Random.Range(2, 4)];
                        }
                        return blocks[Random.Range(2, 4)];
                    }
                    else
                        return blocks[2];
                }
                //clay
                else if (_curWidth < wid * 0.28f || _curHeight < wid * 0.28f || _curWidth > wid * 0.72f || _curHeight > wid * 0.72f)
                {
                    if (_curWidth > wid * 0.24f && _curWidth < wid * 0.8f || _curHeight > wid * 0.24f && _curHeight < wid * 0.8f)
                    {
                        return blocks[Random.Range(3, 5)];
                    }
                    else
                        return blocks[3];
                }
                //dirt
                else if (_curWidth < wid * 0.4f || _curHeight < wid * 0.4f || _curWidth > wid * 0.60f || _curHeight > wid * 0.60f)
                {
                    {
                        if (_curWidth > wid * 0.32f || _curWidth < wid * 0.68f || _curHeight > wid * 0.32f || _curHeight < wid * 0.68f)
                        {
                            if (Random.Range(1f, 10f) >= 9.8f) {
                                GameObject temp = new GameObject("temp");
                                temp.tag = "garbage";
                                return temp;
                            }
                            else
                            return blocks[Random.Range(3, 5)];
                        }
                        else
                            return blocks[4];
                    }
                }

                //dirt spread in center
                else if (_curWidth > wid * 0.41f && _curWidth < wid * 0.45f || _curWidth > wid * 0.56f && _curWidth < wid * 0.61f ||
                        _curHeight > wid * 0.55f && _curHeight < wid * 0.7f ||
                        _curHeight > wid * 0.35f && _curHeight < wid * 0.45f)
                {
                    if (Random.Range(1f, 10f) > 6) {
                        GameObject temp = new GameObject("temp");
                        temp.tag = "garbage";
                        return temp;
                    }
                    else
                        return blocks[Random.Range(3, 5)];
                }
                return null;
            };

            GameObject curBlock = null;
            //Here we can use a pool instead of a straight up instantiate (rough on performance)
            if (lambdaObject())
            {
                curBlock = Instantiate(lambdaObject());
                curBlock.transform.position = new Vector2(_curWidth, _curHeight);
                //Steel block
                if (curBlock.GetComponent<Steel>() && Random.Range(0f,100f) > 75f)
                {
                    GameObject gemBabe = Instantiate(gemBaby, curBlock.transform);
                    curBlock.GetComponent<Block>().GemBlock = true;
                }
                //Stone block
                else if(curBlock.GetComponent<Stone>() && Random.Range(0f, 100f) > 85f)
                {
                    GameObject gemBabe = Instantiate(gemBaby, curBlock.transform);
                    curBlock.GetComponent<Block>().GemBlock = true;
                }
                //Clay block
                else if (curBlock.GetComponent<Clay>() && Random.Range(0f, 100f) > 90f)
                {
                    GameObject gemBabe = Instantiate(gemBaby, curBlock.transform);
                    curBlock.GetComponent<Block>().GemBlock = true;
                }
                //Dirt block
                else if (curBlock.GetComponent<Dirt>() && Random.Range(0f, 100f) > 95f)
                {
                    GameObject gemBabe = Instantiate(gemBaby, curBlock.transform);
                    curBlock.GetComponent<Block>().GemBlock = true;
                }
            }

            if (i != 1 && i % blockFieldSize == blockFieldSize - 1)
            {
                _curWidth = 0;
                _curHeight += step;
            }

            if (curBlock)
                spawnedTiles.Add(curBlock);
            
            if (spaceCount != 0 && spaceCount % 20 == 0)
            {
                spaceTrigger = true;
                trigReset = _curHeight;
            }

            if (spaceTrigger)
            {
                if (_curHeight != trigReset)
                {
                    spaceTrigger = false;
                    trigReset = 0;
                }
            }

            //Check Clear Space 
            if (i >= startBlock &&
                i < endBlock &&
                _curWidth >= (blockFieldSize * _step) * 0.4f &&
                _curWidth <= (blockFieldSize * _step) * 0.6f &&
                spaceCount <= (20 * 20) &&
                !spaceTrigger)
            {
                spaceCount++;
            }

            //Character Spawn Point
            float mid = (blockFieldSize * _step) / 2;
            if (!spawnPlaced)
            {
                spawnPlaced = true;
                if (!charSpawnObject)
                {
                    charSpawnObject = new GameObject("SpawnPoint");
                    charSpawnObject.transform.position = new Vector2(mid, mid - 2);
                }
                else
                {
                    var temp = Instantiate(charSpawnObject, new Vector2(mid, mid - 2), Quaternion.identity);
                }
                sandGrid.transform.position = new Vector2(mid, mid);
            };

            _curWidth += step;
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("garbage"))
        {
            Destroy(item);
        }
    }
}
