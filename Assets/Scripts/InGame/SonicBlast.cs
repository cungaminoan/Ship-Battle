using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicBlast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,5f);
    }
    private void Update()
    {
        
    }
    private void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
