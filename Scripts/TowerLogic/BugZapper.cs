using UnityEngine;
using System.Collections;

public class BugZapper : Tower {

	public BugZapper()
    {
        range = 3f; //since it's melee.
        damage *= 2;
        cooldown *= .5f;
    }
}
