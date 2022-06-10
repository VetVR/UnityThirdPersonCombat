using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SwitchState(State newState)
    {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();  //questionmark is checking for that the new state isn't a null state
        
    }


    // Update is called once per frame
    public void Update()
    {
        currentState?.Tick(Time.deltaTime);
        
    }
}
