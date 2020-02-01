﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private DrillController drill;
    private Animator playerAnimator;
    private Animator drillAnimator;
    public float speed = 4;
    private static int gems = 0;
    public Animation anim;
    private List<ShipComponent> components;
    [SerializeField]
    private List<PlayerState> mCurrentStates = new List<PlayerState>();

    // looking where youre moving components
    private GameObject playerSprite;
    Vector2 previousPos = new Vector2(0, 0);
    Vector2 moveDirection = new Vector2(0, 0);
    float angle = 0;

    public int GetGems()
    {
        return gems;
    }

    public void SetGems(int value)
    {
        gems = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        drill = GetComponentInChildren<DrillController>();
        anim = GetComponentInChildren<Animation>();
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        drillAnimator = drill.GetComponent<Animator>();
        playerSprite = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);        

        CheckInputs();
        UpdateAnimations();

        bool found = false;
        for (int i = 0; i < mCurrentStates.Count; i++)
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
            for (int i = 0; i < mCurrentStates.Count; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    found = true;
                }
                if (mCurrentStates[i] == PlayerState.IDLE)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
            if (found == false)
            {
                mCurrentStates.Add(PlayerState.DRILLING);
            }
        }
        //if (!Input.GetMouseButton(0))
        else
        {
            for (int i = 0; i < mCurrentStates.Count; i++)
            {
                if (mCurrentStates[i] == PlayerState.DRILLING)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            bool found = false;
            for (int i = 0; i < mCurrentStates.Count; i++)
            {
                if (mCurrentStates[i] == PlayerState.MOVING)
                {
                    found = true;
                }
                if (mCurrentStates[i] == PlayerState.IDLE)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
            if (found == false)
            {
                mCurrentStates.Add(PlayerState.MOVING);
            }
        }
        else
        {
            for (int i = 0; i < mCurrentStates.Count; i++)
            {
                if (mCurrentStates[i] == PlayerState.MOVING)
                {
                    mCurrentStates.RemoveAt(i);
                }
            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetMouseButton(0))
        {
            bool found = false;
            for (int i = 0; i < mCurrentStates.Count; i++)
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
            for (int i = 0; i < mCurrentStates.Count; i++)
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

    void UpdateAnimations()
    {
        bool found1 = false;
        for (int i = 0; i < mCurrentStates.Count; i++)
        {
            if (mCurrentStates[i] == PlayerState.MOVING)
            {
                found1 = true;
            }
        }
        if (found1 == true)
        {
            //Set animator bool to true and make the sprite face the forward vector
            playerAnimator.SetBool("bMoving", true);
            moveDirection = new Vector2(transform.position.x, transform.position.y) - previousPos;
            if (moveDirection != Vector2.zero)
            {
                angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

                Quaternion newRotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
                playerSprite.transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1.0f);
            }
            previousPos = transform.position;
        }
        else if (found1 == false)
        {
            playerAnimator.SetBool("bMoving", false);
        }
        bool found2 = false;
        for (int i = 0; i < mCurrentStates.Count; i++)
        {
            if (mCurrentStates[i] == PlayerState.DRILLING)
            {
                found2 = true;
            }
        }
        if (found2 == true)
        {
            drillAnimator.SetBool("bDrilling", true);
        }
        else if (found2 == false)
        {
            drillAnimator.SetBool("bDrilling", false);
        }
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

