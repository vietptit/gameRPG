using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieState : playerState
{
    public DieState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 3f;
    }


    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            SceneManager.LoadScene(1);
    }


    public override void Exit()
    {
        base.Exit();
    }
}
