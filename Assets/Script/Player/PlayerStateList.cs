
using System;
using Script.Player;
using UnityEngine;

public class PlayerStateList
{

    private PlayerIdleState PlayerIdleState { get; }
    private PlayerWalkState PlayerWalkState { get; }


    public PlayerStateList(PlayerMotor playerMotor)
    {

        PlayerIdleState = new PlayerIdleState(playerMotor);
        PlayerWalkState = new PlayerWalkState(playerMotor);

    }

    public PlayerBaseState GetState(PlayerStates state)
    {
        return state switch
        {
            PlayerStates.IDLE => PlayerIdleState,
            PlayerStates.WALK => PlayerWalkState,
            _ => throw new Exception("This state does not exist!")
        };
    }
    
}
