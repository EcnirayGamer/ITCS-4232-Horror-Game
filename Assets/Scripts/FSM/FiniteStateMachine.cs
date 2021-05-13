using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.FSM
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField]
        private AbstractState _startingState;

        private AbstractState _currentState;

        private void Awake()
        {
            _currentState = null;
        }

        // Start is called before the first frame update
        private void Start()
        {
            if (_startingState != null)
            {
                EnterState(_startingState);
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        #region State Managment

        public void EnterState(AbstractState nextState)
        {
            if (nextState == null)
            {
                return;
            }

            _currentState = nextState;
            _currentState.EnterState();
        }

        #endregion State Managment
    }
}