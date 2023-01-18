using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{

    protected readonly PlayerMotor PlayerMotor;

    protected PlayerBaseState(PlayerMotor playerMotor)
    {
        PlayerMotor = playerMotor;
    }
    
    public abstract void InitializeState();
    
    public abstract void UpdateState();
    
    public abstract void FixedUpdateState();
    
    protected abstract void CheckSwitchState();
    
    public abstract void ExitState();
    
}
