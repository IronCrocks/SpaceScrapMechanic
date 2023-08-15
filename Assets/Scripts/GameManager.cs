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

    public void CreatePlayerShip()
    {
        GameObject playerShip = null;
        int maxWeaponsCount = 0;

        switch (Progress.Instance.PlayerInfo.SelectedShip)
        {
            case PlayerShips.Default:
                playerShip = Instantiate(DefaultPlayerShipPrefab, Player.transform);
                maxWeaponsCount = 5;
                break;
            case PlayerShips.RelictShip:
                playerShip = Instantiate(RelictPlayerShipPrefab, Player.transform);
                maxWeaponsCount = 10;
                break;
            default:
                break;
        }

        var playerStats = playerShip.GetComponent<PlayerStats>();
        playerStats.MaxWeaponCountLevel = maxWeaponsCount;
    }

    public void KillEnemies()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemies");

        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
