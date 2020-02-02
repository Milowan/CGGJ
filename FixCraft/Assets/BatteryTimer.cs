using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private int mTotalTime = 0;
    private int mMilliseconds = 0;
    private int mSeconds = 0;
    private int mMinutes = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        Debug.Log(GetTotalTimePassed());
    }

    private int CountTime()
    {
        mMilliseconds += 1;
        if (mMilliseconds == 60)
        {
            mMilliseconds = 0;
            mSeconds += 1;
            if (mSeconds == 60)
            {
                mSeconds = 0;
                mMinutes += 1;
            }
        }
        return GetTotalTimePassed();
    }

    public int GetTotalTimePassed()//in minutes
    {
        mTotalTime = mMinutes;
        return mTotalTime;
    }
}
