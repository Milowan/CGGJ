using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<PlayerState> mCurrentStates = new List<PlayerState>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    void CheckInputs()
    {
        if (Input.GetMouseButtonDown(0)) // returns true while left mouse is down
        {
            mCurrentStates.Add(PlayerState.DRILLING);
        }
        else
        {
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
        }
    }

    List<PlayerState> GetPlayerStates()
    {
        return mCurrentStates;
    }
}
