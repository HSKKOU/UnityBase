using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace StateMachine {
	
	/// <summary>
	/// StateMachineを実装するクラスの基底クラス
	/// </summary>
	public abstract class StatefulObjectBase<T, TEnum> : MonoBehaviour where T : class where TEnum : System.IConvertible {

		/// <summary>
		/// 所持しているStateのList
		/// </summary>
		protected List<State<T>> stateList = new List<State<T>>();

		protected StateMachine<T> stateMachine;

		/// <summary>
		/// 現在のState
		/// </summary>
		[SerializeField]
		protected TEnum currentState;

		/// <summary>
		/// Stateの切り替え
		/// </summary>
		public virtual void ChangeState(TEnum state) {
			if (stateMachine == null) { return; }
			currentState = state;
//			Debug.Log ("Change State to " + currentState.ToString() + ": " + typeof(T).ToString());
			stateMachine.ChangeState(stateList[state.ToInt32(null)]);
		}

		/// <summary>
		/// 現在のStateの確認
		/// </summary>
		public virtual bool IsCurrentState(TEnum state) {
			if (stateMachine == null) { return false; }
			return stateMachine.CurrentState == stateList[state.ToInt32(null)];
		}

		protected virtual void Update() {
			if (stateMachine != null) {
				stateMachine.Update ();
			}
		}


		/// <summary>
		/// StateMachineを積んだclassは必ずInitializeメソッドを実装する。
		/// </summary>
		public virtual void Initialize() {
			this.stateMachine = new StateMachine<T>();
		}
	}
}
