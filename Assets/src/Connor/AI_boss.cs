using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_boss : AI
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //DON'T spawn new AI and kill
    public override void kill()
    {
        //TODO - create unique kill animation
        Destroy(gameObject);
    }
}
