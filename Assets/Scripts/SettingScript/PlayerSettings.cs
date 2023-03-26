using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Settings/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float jumpForce;
    public int baseDamage;
    public GameObject bulletPrefab;
    public float fireRate;
    public float bulletSpeed;
    public int magMaxSize;
}
