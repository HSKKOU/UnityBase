using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace StateMachine {

	public class StatefulSingletonMono<T, TEnum> : SingletonMono<T> where T : MonoBehaviour where TEnum : System.IConvertible {

		/// <summary>
		/// 所持しているStateのList
		/// </summary>
		protected List<State<T>> stateList = new List<State<T>>();

		protected StateMachine<T> stateMachine;

		/// <summary>
		/// Stateの切り替え
		/// </summary>
		public virtual void ChangeState(TEnum state) {
			if (stateMachine == null) { return; }
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



		public virtual void Initialize() {
			Debug.Log (typeof(T).ToString() + " is Singleton, but not implemented a mothod 'Initialize'");
		}
	}
}
