using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public Player player;
    public Text gemAmount;
    public Sprite coneSprite;
    public Sprite engineSprite;
    public Sprite fuelSprite;
    public Sprite wingSprite;
    int gems;
    GameObject[] uiShipSlots = new GameObject[4];
    List<ShipComponent> currentParts = new List<ShipComponent>();

    public List<ShipComponent> shipsSprites = new List<ShipComponent>();

    private void Start()
    {
        player = Player.GetInstance();
        for (int i = 0; i < uiShipSlots.Length; i++)
        { 
            uiShipSlots[i] = gameObject.transform.GetChild(0).GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        gems = player.GetGems();
        gemAmount.text = " = " + gems;
        currentParts = player.GetShipComponents();

    }

    private void LateUpdate()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        for (int i = 0; i < currentParts.Count; i++)
        {
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.CONE)
            {
                uiShipSlots[0].GetComponent<Image>().sprite = coneSprite;
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.ENGINE)
            {
                uiShipSlots[1].GetComponent<Image>().sprite = engineSprite;
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.FUEL)
            {
                uiShipSlots[2].GetComponent<Image>().sprite = fuelSprite;
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.WING)
            {
                uiShipSlots[3].GetComponent<Image>().sprite = wingSprite;
            }
        }
    }
}
