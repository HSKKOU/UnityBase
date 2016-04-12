using UnityEngine;
using System.Collections;

using StateMachine;
using Inputs;

namespace Game {

	/// <summary>
	/// PlayerManagerのState
	/// </summary>
	public enum PlayerManagerState {
		Init,		// 初期化
		Stay,		// 待機中
		Moving,		// 移動中
		Deinit,		// 終了処理
		Num,
	}

	/// <summary>
	/// Player管理クラス
	/// </summary>
	public class PlayerManager : StatefulSingletonMono<PlayerManager, PlayerManagerState> {

		private PlayerController playerController;

		[SerializeField]
		private float playerSpeed_;
		public float playerSpeed {
			get { return playerSpeed_; }
			private set { playerSpeed_ = value; }
		}

		/// <summary>
		/// PlayerManagerの初期化
		/// </summary>
		public override void Initialize() {
			base.Initialize ();

			// 順番はenumの順番と同じ順番で
			stateList.Add(new StateInit(this));
			stateList.Add(new StateStay(this));
			stateList.Add(new StateMoving(this));
			stateList.Add(new StateDeinit(this));

			// 初期化する
			ChangeState(PlayerManagerState.Init);
		}


		private void Move() {
			playerController.Move ();
		}



		/* --- states ---------------------------------------------------- */

		/// <summary>
		/// PlayerManagerの初期化State
		/// </summary>
		private class StateInit: State<PlayerManager> {
			public StateInit(PlayerManager owner): base(owner) {}

			public override void Enter() {
				owner.playerController = PlayerController.Instance;

				// Eventの登録
				InputManager.Instance.OnDownSpaceKeyEvent += owner.Move;
				owner.ChangeState (PlayerManagerState.Stay);
			}
			public override void Execute() {}
			public override void Exit() {}
		}

		/// <summary>
		/// PlayerManagerの待機中State
		/// </summary>
		private class StateStay: State<PlayerManager> {
			public StateStay(PlayerManager owner): base(owner) {}

			public override void Enter() {}
			public override void Execute() {}
			public override void Exit() {}
		}

		/// <summary>
		/// PlayerManagerの移動中State
		/// </summary>
		private class StateMoving: State<PlayerManager> {
			public StateMoving(PlayerManager owner): base(owner) {}

			public override void Enter() {}
			public override void Execute() {}
			public override void Exit() {}
		}

		/// <summary>
		/// PlayerManagerの終了処理State
		/// </summary>
		private class StateDeinit: State<PlayerManager> {
			public StateDeinit(PlayerManager owner): base(owner) {}

			public override void Enter() {
				// Eventの抹消
				InputManager.Instance.OnDownSpaceKeyEvent -= owner.Move;
			}
			public override void Execute() {}
			public override void Exit() {}
		}
	}
}
