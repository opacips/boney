using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "ScriptableObject/Create Block Data")]
public class BlockData : ScriptableObject
{
    public Sprite blockSprite;
    public GameObject blockPrefab;
    public string blockName;
}

