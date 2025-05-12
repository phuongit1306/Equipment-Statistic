using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string weaponName;
    public Sprite weaponSprite;
    public int damage;
    public int dispersion;
    public int rateOfFire;
    public int reloadSpeed;
    public int ammo;
    public WeaponStatus currentStatus = WeaponStatus.None;
}

public enum WeaponStatus { None, Used, Rented }
