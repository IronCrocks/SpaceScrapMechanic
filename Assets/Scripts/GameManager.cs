using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject DefaultPlayerShipPrefab;
    public GameObject RelictPlayerShipPrefab;

    private void Awake()
    {
        CreatePlayerShip();
    }

    private void CreatePlayerShip()
    {
        GameObject playerShip = null;
        int maxWeaponsCount = 0;

        switch (PlayerData.SelectedShip)
        {
            case PlayerShips.Default:
                playerShip = GameObject.Instantiate(DefaultPlayerShipPrefab, Player.transform);
                maxWeaponsCount = 5;
                break;
            case PlayerShips.RelictShip:
                playerShip = GameObject.Instantiate(RelictPlayerShipPrefab, Player.transform);
                maxWeaponsCount = 10;
                break;
            default:
                break;
        }

        var playerStats = playerShip.GetComponent<PlayerStats>();
        playerStats.MaxWeaponCountLevel = maxWeaponsCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
