using UnityEngine;
using System.Collections;

public class Catapult : Tower {

    public Catapult()
    {
        damage *= 5;
        cooldown *= 3;
        range *= 5;
    }
	
}
