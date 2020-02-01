using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private DrillController drill;
    public int speed = 4;
    private static int gems = 300;
    public Animation anim;
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 1000);
            Debug.Log(hit.point);
        }

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
            Debug.Log("ButtonDOWN");
            drill.MineBlock();
            //anim.Play("TESTDRILL");
            found = false;
        }
        else if (found == false)
        {
            Debug.Log("ButtonUP");
            //anim.Stop("TESTDRILL");

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
}

