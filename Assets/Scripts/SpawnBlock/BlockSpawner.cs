using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SpawnBlock
{
    public class BlockSpawner : MonoBehaviour
    {
        public Vector3 spawnPoint = new Vector3(0f, 0f, 0f);
        public int MaxClick = 4;
        public void Spawner(BlockData blockData)
        {
            if(MaxClick > 0)
            {
                switch (blockData.blockName)
                {
                    case "DBlock":
                        Instantiate(blockData.blockPrefab, spawnPoint, Quaternion.identity);
                        MaxClick--;
                        break;
                    case "CBlock":
                        Instantiate(blockData.blockPrefab, spawnPoint, Quaternion.identity);
                        MaxClick--;
                        break;
                    case "ZBlock":
                        Instantiate(blockData.blockPrefab, spawnPoint, Quaternion.identity);
                        MaxClick--;
                        break;
                    case "SquareBlock":
                        Instantiate(blockData.blockPrefab, spawnPoint, Quaternion.identity);
                        MaxClick--;
                        break;
                    case "ColumnBlock":
                        Instantiate(blockData.blockPrefab, spawnPoint, Quaternion.identity);
                        MaxClick--;
                        break;
                    default:
                        Debug.Log("Invalid Option");
                        break;
                }
                Debug.Log($"Estimate Click: {MaxClick}");
            }
            
            
        }

    }

  
}