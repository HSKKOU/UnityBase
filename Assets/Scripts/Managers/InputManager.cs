using UnityEngine;
using System;
using System.Collections;

using Utils;

namespace Inputs {

	/// <summary>
	/// Input管理クラス
	/// </summary>
	public class InputManager : SingletonMono<InputManager> {

		public Action OnDownSpaceKeyEvent = delegate {};

		void Start() {
			/* do nothing */
		}

		void Update() {
			// Spaceキーが押されたらEventを実行
			if(Input.GetKey(KeyCode.Space)) {
				OnDownSpaceKeyEvent ();
			}
		}
	}
}
