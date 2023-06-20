using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int WeaponCountLevel { get; set; } = 1;
    public int WeaponPowerLevel { get; set; } = 1;
    public int WeaponFireRateLevel { get; set; } = 1;

    public int MaxWeaponCountLevel { get; set; }
    public int MaxWeaponPowerLevel { get; set; } = 1;
    public int MaxWeaponFireRateLevel { get; set; } = 5;

    public List<GameObject> Weapons;
}
