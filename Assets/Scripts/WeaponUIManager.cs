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
        // Set trạng thái mặc định cho 2 súng đầu
        if (weaponItemUIs.Count > 0)
            weaponItemUIs[0].UpdateStatus(WeaponStatus.Used);

        if (weaponItemUIs.Count > 1)
            weaponItemUIs[1].UpdateStatus(WeaponStatus.Rented);

        // Bắt sự kiện nút
        useButton.onClick.AddListener(OnUseWeapon);
        rentOutButton.onClick.AddListener(OnRentOutWeapon);
    }

    public void SelectWeapon(WeaponItemUI weapon)
    {
        // Tắt viền tất cả
        foreach (var w in weaponItemUIs)
            w.DisableGlow();

        // Bật viền súng đang chọn
        weapon.EnableGlow();

        // Hiển thị thông tin
        mainWeaponImage.sprite = weapon.GetSprite();
        weaponNameText.text = weapon.GetWeaponName();
        damageText.text = weapon.GetDamage().ToString();
        dispersionText.text = weapon.GetDispersion().ToString();
        rateOfFireText.text = weapon.GetRateOfFire() + " RPM";
        reloadSpeedText.text = weapon.GetReloadSpeed() + "%";
        ammoText.text = weapon.GetAmmo() + "/100";

        // Gán weapon đang chọn
        currentSelected = weapon;
    }

    void OnUseWeapon()
    {
        if (currentSelected == null) return;

        // Nếu đang Rented thì không cho dùng
        if (currentSelected.GetStatus() == WeaponStatus.Rented)
        {
            Debug.Log("Đã cho người khác thuê - không thể dùng!");
            return;
        }

        currentSelected.UpdateStatus(WeaponStatus.Used);
    }

    void OnRentOutWeapon()
    {
        if (currentSelected == null) return;

        currentSelected.UpdateStatus(WeaponStatus.Rented);
    }
}
