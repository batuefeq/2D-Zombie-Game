using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Settings/PlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float jumpForce;
    public int baseDamage;
    public GameObject bulletPrefab;
    public GameObject muzzlePrefab;
    public float fireRate;
    public float bulletSpeed;
    public int magMaxSize;
    public float stabTime;
    public float airStabTime;
    public float stabRate;
    public int maxUltimatePoint;
}
