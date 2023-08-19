using System;

[Serializable]
public class GameData
{
    public int RelictCrystalsCount { get; set; }
    public PlayerShips SelectedShip { get; set; }
    public bool IsRelictShipUnlocked { get; set; }
}
