using UnityEngine;

[CreateAssetMenu(fileName = "Zombie Settings", menuName = "Settings/Zombie Settings", order = 2)]
public class ZombieSettings : ScriptableObject
{
    public int health;
    public float maxSpeed;
    public float minSpeed;
    public float incrementSpeed;
    public float bulletImpactSpeed;
}
