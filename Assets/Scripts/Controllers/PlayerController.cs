using UnityEngine;
using System.Collections;

using Utils;

namespace Game {

	/// <summary>
	/// Player操作クラス
	/// </summary>
	public class PlayerController : SingletonMono<PlayerController> {

		/// <summary>
		/// PlayerControllerの初期化
		/// </summary>
		public void Initialize() {
			/* do nothing */
		}

		/// <summary>
		/// Playerを動かす
		/// </summary>
		public void Move() {
			Debug.Log ("Move " + PlayerManager.Instance.playerSpeed * Time.deltaTime);
			transform.AddTransformPositionX (PlayerManager.Instance.playerSpeed * Time.deltaTime);
		}
	}
}
