using UnityEngine;
using System.Collections;
using StateMachine;

namespace Game {

	/// <summary>
	/// GameManagerのState
	/// </summary>
	public enum GameManagerState {
		Init,		// 初期化
		Playing,	// プレイ中
		Num,
	}

	/// <summary>
	/// Game全体管理クラス
	/// </summary>
	public class GameManager : StatefulSingletonMono<GameManager, GameManagerState> {
		private PlayerManager playerManager;

		public void Awake() {
			// スマホなどでマルチタッチを無効にする。
//			Input.multiTouchEnabled = false;

			// GameManagerが全ての大元を管理するため
			// 管理クラスは全てこのメソッドから伝番して初期化させる。
			Initialize ();
		}

		/// <summary>
		/// GameManagerの初期化
		/// </summary>
		public override void Initialize() {
			base.Initialize ();

			// 順番はenumの順番と同じ順番で
			stateList.Add(new StateInit(this));
			stateList.Add(new StatePlaying(this));

			// 初期化する
			ChangeState(GameManagerState.Init);
		}





		/* --- states ---------------------------------------------------- */

		/// <summary>
		/// GameManagerの初期化State
		/// </summary>
		private class StateInit: State<GameManager> {
			public StateInit(GameManager owner): base(owner) {}

			public override void Enter() {
				owner.playerManager = PlayerManager.Instance;
				owner.playerManager.Initialize ();

				owner.ChangeState (GameManagerState.Playing);
			}
			public override void Execute() {}
			public override void Exit() {}
		}

		/// <summary>
		/// GameManagerのゲームプレイ中State
		/// </summary>
		private class StatePlaying: State<GameManager> {
			public StatePlaying(GameManager owner): base(owner) {}

			public override void Enter() {}
			public override void Execute() {}
			public override void Exit() {}
		}
	}
}
