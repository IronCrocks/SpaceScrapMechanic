using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipSettings : MonoBehaviour
{
    public Image ShipIcon;

    public List<GameObject> Ships;
    public Slider WeaponSlider;
    public Slider AccelerationSlider;
    public Slider SpeedSlider;
    public Button UnlockButton;
    public Button SelectButton;
    public TMP_Text ShipCost;
    public GameObject shipLock;

    private PlayerShips _viewedShip;
    private int _relictShipCost = 100;

    private void OnEnable()
    {
        switch (GameData.SelectedShip)
        {
            case PlayerShips.Default:
                ShowDefaultShip();
                break;
            case PlayerShips.RelictShip:
                ShowRelictShip();
                break;
            default:
                break;
        }
    }

    public void ToggleShip()
    {
        switch (_viewedShip)
        {
            case PlayerShips.Default:
                ShowRelictShip();
                break;
            default:
                ShowDefaultShip();
                break;
        }
    }

    private void ShowDefaultShip()
    {
        ShipIcon.sprite = Ships[0].GetComponent<SpriteRenderer>().sprite;
        ShipIcon.gameObject.transform.localScale = new Vector3(1, 0.8f, 1);
        WeaponSlider.value = 0.5f;
        AccelerationSlider.value = 0.6f;
        SpeedSlider.value = 0.7f;

        _viewedShip = PlayerShips.Default;

        UnlockButton.gameObject.SetActive(false);
        SelectButton.gameObject.SetActive(true);
        shipLock.SetActive(false);

        SelectButton.interactable = GameData.SelectedShip != PlayerShips.Default;
        ShipCost.text = "Приоберетен";
    }

    private void ShowRelictShip()
    {
        ShipIcon.sprite = Ships[1].GetComponent<SpriteRenderer>().sprite;
        ShipIcon.gameObject.transform.localScale = new Vector3(1, 1, 1);
        WeaponSlider.value = 1f;
        AccelerationSlider.value = 1f;
        SpeedSlider.value = 1f;

        _viewedShip = PlayerShips.RelictShip;

        if (GameData.IsRelictShipUnlocked)
        {
            UnlockButton.gameObject.SetActive(false);
            SelectButton.gameObject.SetActive(true);
            shipLock.SetActive(false);

            SelectButton.interactable = GameData.SelectedShip == PlayerShips.Default;
            ShipCost.text = "Приоберетен";
        }
        else
        {
            SelectButton.gameObject.SetActive(false);
            UnlockButton.gameObject.SetActive(true);
            shipLock.SetActive(true);

            UnlockButton.interactable = GameData.RelictCrystalsCount >= _relictShipCost;
            ShipCost.text = _relictShipCost.ToString();
        }

    }

    public void Unlock()
    {
        GameData.RelictCrystalsCount -= _relictShipCost;
        GameData.IsRelictShipUnlocked = true;

        ShowRelictShip();
    }

    public void SelectShip()
    {
        GameData.SelectedShip = _viewedShip;
        SelectButton.interactable = false;
    }
}
