using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // Start is called before the first frame update
    public void Start()
    {
        SwitchState(new PlayerTestState(this));
    }

    
}
