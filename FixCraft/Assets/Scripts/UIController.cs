using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Player player;
    public Text gemAmount;
    int gems;
    List<ShipComponent> uiList = new List<ShipComponent>();

    public List<ShipComponent> shipsSprites = new List<ShipComponent>();

    private void Awake()
    {
        //uiList = Player.GetShipComponents();
        gems = player.GetGems();
    }
    private void Update()
    {
        gemAmount.text = " = " + gems;
        player = FindObjectOfType<Player>();

    }
    private void LateUpdate()
    {

    }
}
