using UnityEngine;
using System.Collections;

public class StickyShooter : Tower {

	public StickyShooter()
    {
        damage *= .5f;
        range *= 1.5f;
        // slows enemy effect.
    }
}
