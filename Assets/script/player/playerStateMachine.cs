using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateMachine 
{
   public playerState currentState{get;private set;}
   
   public void InitialState(playerState _newState)
   {
        currentState=_newState;
        currentState.Enter();
   }

   public void changeState(playerState _newState)
   {
        currentState.Exit();
        currentState=_newState;
        currentState.Enter();
   }
}
