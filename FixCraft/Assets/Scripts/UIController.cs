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
    GameObject uiTextObject;

    bool isSet = false;

    private void Start()
    {
        for (int i = 0; i < uiShipSlots.Length; i++)
        { 
            uiShipSlots[i] = gameObject.transform.GetChild(1).GetChild(i).gameObject;
        }
        uiTextObject = gameObject.transform.GetChild(1).GetChild(4).GetChild(0).gameObject;
    }

    private void Update()
    {
        if (Player.GetInstance() != null)
        {
            player = Player.GetInstance();
            isSet = true;
        }
        if (isSet)
        {
            gems = player.GetGems();
            gemAmount.text = " = " + gems;
            currentParts = player.GetShipComponents();
        }

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
                uiTextObject.GetComponent<Text>().text = "Picked up the nose cone!";
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.ENGINE)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = engineSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                uiTextObject.GetComponent<Text>().text = "Picked up the thruster!";
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.FUEL)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = fuelSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                uiTextObject.GetComponent<Text>().text = "Picked up the fuel tank!";
            }
            if (currentParts[i].gameObject.GetComponent<ShipComponent>().GetShipComponentType() == ShipComponentType.WING)
            {
                uiShipSlots[i].GetComponent<Image>().sprite = wingSprite;
                uiShipSlots[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                uiTextObject.GetComponent<Text>().text = "Picked up the wing!";
            }
        }
    }
}
