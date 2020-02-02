using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Player player;
    public Text gemAmount;
    int gems;
    GameObject[] uiShipSlots = new GameObject[4];
    List<ShipComponent> currentParts = new List<ShipComponent>();

    public List<ShipComponent> shipsSprites = new List<ShipComponent>();

    private void Start()
    {
        player = Player.GetInstance();
        for (int i = 0; i < uiShipSlots.Length - 1; i++)
        { 
            uiShipSlots[i] = gameObject.transform.GetChild(0).GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        //gems = player.GetGems();
        gemAmount.text = " = " + gems;
        //currentParts = player.GetShipComponents();

    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < currentParts.Count; i++)
        {
            if (uiShipSlots[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.CONE)
            {

            }
        }
    }
}
