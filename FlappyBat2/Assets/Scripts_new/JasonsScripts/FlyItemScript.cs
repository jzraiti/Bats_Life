using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyItemScript : MonoBehaviour
{

    public float occillationAmpY;
    public float occillationAmpX;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(Time.time*2) * occillationAmpX, Mathf.Sin(Time.time)* occillationAmpY);
    }
}
