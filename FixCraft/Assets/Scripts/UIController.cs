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
    [SerializeField]
    List<ShipComponent> currentParts = new List<ShipComponent>();

    private void Start()
    {
        player = Player.GetInstance();
        for (int i = 0; i < uiShipSlots.Length; i++)
        { 
            uiShipSlots[i] = gameObject.transform.GetChild(2).GetChild(i).gameObject;
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
                uiShipSlots[i].GetComponent<Image>().sprite = coneSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.ENGINE)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = engineSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.FUEL)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = fuelSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.WING)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = wingSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
        }
    }
}
