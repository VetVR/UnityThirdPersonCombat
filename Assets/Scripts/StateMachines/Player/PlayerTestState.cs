using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer;

    
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Entering");
        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.InputReader.JumpEvent += OnDodge;
    }

    public override void Tick(float deltaTime)
    {
        timer += deltaTime;
        Debug.Log(timer);

    }
    
    public override void Exit()
    {
        Debug.Log("Exiting");
        stateMachine.InputReader.JumpEvent -= OnJump; 
        stateMachine.InputReader.JumpEvent -= OnDodge;
    }

    public void OnJump()
    {
        //player state change
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }

    public void OnDodge()
    {
        //player state change
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }

    
}
