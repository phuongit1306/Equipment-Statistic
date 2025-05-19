using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponItemUI : MonoBehaviour
{
    [Header("UI Reference")]
    public Image weaponImage;
    public TMP_Text statusText;
    public GameObject glowBorder; // <- thêm GameObject để bật/tắt sáng viền

    [Header("Gun Spec")]
    [SerializeField] private string weaponName;
    [SerializeField] private Sprite weaponSprite;
    [SerializeField] private int damage;
    [SerializeField] private int dispersion;
    [SerializeField] private int rateOfFire;
    [SerializeField] private int reloadSpeed;
    [SerializeField] private int ammo;

    private WeaponUIManager uiManager;
    private WeaponStatus currentStatus;

    void Start()
    {
        uiManager = FindObjectOfType<WeaponUIManager>();
        weaponImage.sprite = weaponSprite;
        statusText.text = "";
        DisableGlow();
    }

    public void OnClick()
    {
        uiManager.SelectWeapon(this);
    }

    public string GetWeaponName() => weaponName;
    public Sprite GetSprite() => weaponSprite;
    public int GetDamage() => damage;
    public int GetDispersion() => dispersion;
    public int GetRateOfFire() => rateOfFire;
    public int GetReloadSpeed() => reloadSpeed;
    public int GetAmmo() => ammo;
    public WeaponStatus GetStatus() => currentStatus;

    public void UpdateStatus(WeaponStatus status)
    {
        currentStatus = status;

        switch (status)
        {
            case WeaponStatus.Used:
                statusText.text = "Used";
                statusText.color = Color.green;
                break;
            case WeaponStatus.Rented:
                statusText.text = "Rented Out";
                statusText.color = new Color(1f, 0.5f, 0f); // Cam
                break;
            default:
                statusText.text = "";
                statusText.color = Color.white;
                break;
        }
    }

    public void EnableGlow() => glowBorder?.SetActive(true);
    public void DisableGlow() => glowBorder?.SetActive(false);
}
