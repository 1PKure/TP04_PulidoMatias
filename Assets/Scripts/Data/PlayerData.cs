using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float life = 100;
}
