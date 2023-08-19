using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject ShipSettingsPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowSettings()
    {
        SettingsPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ShowShipSettings()
    {
        this.gameObject.SetActive(false);
        ShipSettingsPanel.SetActive(true);
    }

    public void Revert()
    {
        if (SettingsPanel.activeSelf)
        {
            SettingsPanel.SetActive(false);
        }
        else
        {
            ShipSettingsPanel.SetActive(false);
        }

        gameObject.SetActive(true);
    }

    private void Awake()
    {
        SettingsPanel.SetActive(false);
        ShipSettingsPanel.SetActive(false);
    }
}
