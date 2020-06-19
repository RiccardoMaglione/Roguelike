using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParticle : MonoBehaviour
{
    public float yAngleTarget;
    public float secondsToLerp;
    float t;
    float tv;
    float td;
    float te;
    float tc;
    float tg;
    // Use this for initialization
    void Start()
    {
        t = 0;
        tv = 0;
        td = 0;
        te = 0;
        tc = 0;
        tg = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(this.gameObject.tag == "RuneWow")
        {
            t += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(-90, Mathf.Lerp(0, yAngleTarget, t), 0);
            if (t > 1)
            {
                t = 0;
            }
        }

        if (this.gameObject.tag == "RuneValvran")
        {
            tv += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, yAngleTarget, tv), 0);
            if (tv > 1)
            {
                tv = 0;
            }
        }
        if (this.gameObject.tag == "RuneGreen")
        {
            tc += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, yAngleTarget, tc), 0);
            if (tc > 1)
            {
                tc = 0;
            }
        }
        if (this.gameObject.tag == "RuneDarkElf")
        {
            td += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, yAngleTarget, td), 0);
            if (td > 1)
            {
                td = 0;
            }
        }
        if (this.gameObject.tag == "RuneEye")
        {
            te += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(-90, Mathf.Lerp(0, yAngleTarget, te), 0);
            if (te > 1)
            {
                te = 0;
            }
        }
        if (this.gameObject.tag == "RuneGammur")
        {
            tg += Time.deltaTime / secondsToLerp;
            transform.rotation = Quaternion.Euler(-90, Mathf.Lerp(0, yAngleTarget, tg), 0);
            if (tg > 1)
            {
                tg = 0;
            }
        }
    }
}