using UnityEngine;
using System.Collections;

public class SniperTower : Tower {

    public SniperTower()
    {
        
        range *= 2;
        damage *= 2;
        cooldown *= 1.5f;
        //MISSING armor penetration
    }
}
