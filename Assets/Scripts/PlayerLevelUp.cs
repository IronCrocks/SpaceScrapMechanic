using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUp : MonoBehaviour
{
    public int expirienceCount = 0;
    public Slider Slider;
    public GameObject LevelUpMenu;
    public CanvasGroup _fadedRelictCrystalsCountText;

    private float maxExpCount = 10;
    private PlayerStats PlayerStats;
    private int _currentLevel;
    private int _maxLevel;

    private void Start()
    {
        Slider.maxValue = maxExpCount;
        PlayerStats = GetComponentInChildren<PlayerStats>();
        _maxLevel = PlayerStats.MaxWeaponCountLevel - 1 + PlayerStats.MaxWeaponFireRateLevel - 1;
        _fadedRelictCrystalsCountText.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateExpCount();
    }

    private void CalculateExpCount()
    {
        if (expirienceCount >= maxExpCount)
        {
            if (_currentLevel < _maxLevel)
            {
                ActivateLevelUpMenu();
            }
            else
            {
                AddRelictCrystals();
            }

            maxExpCount *= 1.5f;
            Slider.maxValue = maxExpCount;
            expirienceCount = 0;
            _currentLevel++;
        }

        Slider.value = expirienceCount;
    }

    private void ActivateLevelUpMenu()
    {
        LevelUpMenu.SetActive(true);
        var levelUpMenuButton1 = LevelUpMenu.transform.GetChild(0);
        var text1 = levelUpMenuButton1.gameObject.GetComponentInChildren<TMP_Text>();

        if (PlayerStats.WeaponCountLevel < PlayerStats.MaxWeaponCountLevel)
        {
            text1.text = "Количество турелей - Уровень " + (PlayerStats.WeaponCountLevel + 1);
        }
        else
        {
            text1.text = "Достигнуто максимальное количество турелей";
            var button1 = levelUpMenuButton1.gameObject.GetComponent<Button>();
            button1.interactable = false;
        }

        var levelUpMenuButton3 = LevelUpMenu.transform.GetChild(1);
        var text3 = levelUpMenuButton3.gameObject.GetComponentInChildren<TMP_Text>();

        if (PlayerStats.WeaponFireRateLevel < PlayerStats.MaxWeaponFireRateLevel)
        {
            text3.text = "Скорость стрельбы - Уровень " + (PlayerStats.WeaponFireRateLevel + 1);
        }
        else
        {
            text3.text = "Достигнута максимальная скорость стрельбы";
            var button3 = levelUpMenuButton3.gameObject.GetComponent<Button>();
            button3.interactable = false;
        }
    }


    public void WeaponCountLevelUp()
    {
        if (PlayerStats.WeaponCountLevel >= PlayerStats.MaxWeaponCountLevel)
        {
            return;
        }

        PlayerStats.Weapons[PlayerStats.WeaponCountLevel].SetActive(true);
        PlayerStats.WeaponCountLevel++;

        AwakeWorld();
    }

    public void WeaponFireRateLevelUp()
    {
        if (PlayerStats.WeaponFireRateLevel >= PlayerStats.MaxWeaponFireRateLevel)
        {
            return;
        }

        PlayerStats.WeaponFireRateLevel++;
        float deltaFireRate = 0.1f;

        foreach (var weapon in PlayerStats.Weapons)
        {
            if (!weapon.activeSelf)
            {
                continue;
            }

            var weaponShoot = weapon.GetComponent<WeaponShoot>();
            weaponShoot.RestartShooting(deltaFireRate);
        }

        AwakeWorld();
    }

    private void AddRelictCrystals()
    {
        GameData.RelictCrystalsCount += 10;
        _fadedRelictCrystalsCountText.alpha = 1;
        InvokeRepeating(nameof(Fade), 0, 0.05f);
    }

    private void Fade() {
        _fadedRelictCrystalsCountText.alpha -= 0.05f;

        if (_fadedRelictCrystalsCountText.alpha <= 0) {
            CancelInvoke(nameof(Fade));
        }
    }

    private void AwakeWorld()
    {
        LevelUpMenu.SetActive(false);
    }
}
