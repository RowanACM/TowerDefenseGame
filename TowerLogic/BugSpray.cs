using UnityEngine;
using System.Collections;

public class BugSpray : Tower {

    public BugSpray()
    {
        range *= .5f;
        cooldown = .05f;
        damage *= .2f;
    }

}
