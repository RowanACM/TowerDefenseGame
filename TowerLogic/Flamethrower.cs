using UnityEngine;
using System.Collections;

public class Flamethrower : Tower {

	public Flamethrower()
    {
        damage *= 2.5f;
        cooldown *= 2;
        range *= 2;
    }
}
