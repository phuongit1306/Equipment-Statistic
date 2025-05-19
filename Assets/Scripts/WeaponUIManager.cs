using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WeaponUIManager : MonoBehaviour
{
    [Header("Main Weapon UI")]
    public Image mainWeaponImage;
    public Button useButton;
    public Button rentOutButton;

    [Header("Weapon Info Texts")]
    public TMP_Text weaponNameText;
    public TMP_Text damageText, dispersionText, rateOfFireText, reloadSpeedText, ammoText;

    [Header("Weapon List")]
    public List<WeaponItemUI> weaponItemUIs;

    private WeaponItemUI currentSelected;

    void Start()
    {
        if (weaponItemUIs.Count > 0)
        weaponItemUIs[0].UpdateStatus(WeaponStatus.Used);

        if (weaponItemUIs.Count > 1)
        weaponItemUIs[1].UpdateStatus(WeaponStatus.Rented);
        
        useButton.onClick.AddListener(OnUseWeapon);
        rentOutButton.onClick.AddListener(OnRentOutWeapon);
    }

    public void SelectWeapon(WeaponItemUI weapon)
    {
        mainWeaponImage.sprite = weapon.GetSprite();
        weaponNameText.text = weapon.GetWeaponName();
        damageText.text = weapon.GetDamage().ToString();
        dispersionText.text = weapon.GetDispersion().ToString();
        rateOfFireText.text = weapon.GetRateOfFire() + " RPM";
        reloadSpeedText.text = weapon.GetReloadSpeed() + "%";
        ammoText.text = weapon.GetAmmo() + "/100";

        currentSelected = weapon;
    }

    void OnUseWeapon()
    {
        if (currentSelected != null)
        {
            currentSelected.UpdateStatus(WeaponStatus.Used);
        }
    }

    void OnRentOutWeapon()
    {
        if (currentSelected != null)
        {
            currentSelected.UpdateStatus(WeaponStatus.Rented);
        }
    }
}
