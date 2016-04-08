using UnityEngine;
using System.Collections;

public class Fan : Tower {
    private float aoeRange = 5.0f;

    
	public Fan()
    {

        cooldown = .1f;
        range = 5f;
    }

}
