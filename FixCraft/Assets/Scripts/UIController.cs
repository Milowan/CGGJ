using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    Player player;
    public Text gemAmount;
    int gems;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        gems = player.GetGems();
        gemAmount.text = "" + gems;

    }
}
