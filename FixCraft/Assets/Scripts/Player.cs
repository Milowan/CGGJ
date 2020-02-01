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
            bool found = false;
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                mCurrentStates.Add(PlayerState.DRILLING);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            bool found = false;
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.MOVING)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                mCurrentStates.Add(PlayerState.MOVING);
            }
        }
        else
        {
            bool found = false;
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.IDLE)
                {
                    found = true;
                }
            }
            if (found == false)
            {
                mCurrentStates.Add(PlayerState.IDLE);
            }
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] != PlayerState.IDLE)
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
