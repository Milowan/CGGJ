﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private DrillController drill;
    public float speed = 4;
    private static int gems = 0;
    public Animation anim;
    private List<ShipComponent> components;

    public int GetGems()
    {
        return gems;
    }

    public void SetGems(int value)
    {
        gems = value;
    }

    private List<PlayerState> mCurrentStates = new List<PlayerState>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drill = GetComponentInChildren<DrillController>();
        anim = GetComponentInChildren<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        CheckInputs();

        bool found = false;
        for (int i = 0; i < mCurrentStates.Count - 1; i++)
        {
            if (mCurrentStates[i] == PlayerState.DRILLING)
            {
                found = true;
            }
        }
        if (found == true)
        {
            drill.Mine(); 
            found = false;
        }
        else if (found == false)
        {

            drill.StopMine();
        }

    }

    void CheckInputs()
    {
        if (Input.GetMouseButton(0)) // returns true while left mouse is down
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
        else if (!Input.GetMouseButton(0))
        {
            for (int i = 0; i < mCurrentStates.Count - 1; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
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

    public void CollectComponent(ShipComponent shipComponent)
    {
        components.Add(shipComponent);
    }

    public void AttachComponentsToShip(Ship ship)
    {
        foreach(ShipComponent component in components)
        {
            ship.AttachComponent(component);
        }

        components.Clear();
    }
}

