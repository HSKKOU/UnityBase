namespace StateMachine {
	
	/// <summary>
	/// State管理クラス
	/// </summary>
	public class StateMachine<T> {

		/// <summary>
		/// 現在のState
		/// </summary>
		private State<T> currentState;

		public StateMachine() { currentState = null; }

		/// <summary>
		/// 現在のStateのgetter
		/// </summary>
		public State<T> CurrentState {
			get { return currentState; }
		}

		/// <summary>
		/// Stateの切り替え
		/// </summary>
		public void ChangeState(State<T> state) {
			if (currentState != null) { currentState.Exit(); }
			currentState = state;
			currentState.Enter();
		}

		public void Update() {
			if (currentState != null) { currentState.Execute(); }
		}
	}
}
