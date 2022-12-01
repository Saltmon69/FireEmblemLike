using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void Execute(BaseStateMachine machine) { }
    }
}
