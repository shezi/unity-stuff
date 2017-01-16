The Documentation defines the Problem as followed: "Note that position constraints are applied in World space, and rotation constraints are applied in Local space."  
https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html

But I needed the Movement lock on local space, so this will fix that.

Just attach this script to any Object that contains the Rigidbody and the local pistion will be locked.
