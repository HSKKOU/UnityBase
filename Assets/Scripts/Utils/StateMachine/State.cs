namespace StateMachine {

	/// <summary>
	/// 各Stateの基底クラス
	/// </summary>
	public class State<T> {
		
		/// <summary>
		/// このステートを利用するインスタンス
		/// </summary>
		protected T owner;

		public State(T owner)	{
			this.owner = owner;
		}

		/// <summary>
		/// このステートに遷移する時に一度だけ呼ばれる
		/// </summary>
		public virtual void Enter() {}

		/// <summary>
		/// このステートである間、毎フレーム呼ばれる
		/// </summary>
		public virtual void Execute() {}

		/// <summary>
		/// このステートから他のステートに遷移するときに一度だけ呼ばれる
		/// </summary>
		public virtual void Exit() {}
	}
}
