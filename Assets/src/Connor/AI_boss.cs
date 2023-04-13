using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AI_boss : AI
{
    //insurance of singleton properties
    private static readonly AI_boss instance = new AI_boss();

    static AI_boss() {}

    private AI_boss() {} // call the base constructor with a value for health

    public static AI_boss Instance
    {
        get { return instance; }
    }


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
