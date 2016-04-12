using UnityEngine;

namespace Utils {

	public static class TransformUtils {
		public static void AddTransformPosition(this Transform transform, Vector3 v) {
			Vector3 newPos = transform.position + v;
			transform.position = newPos;
		}

		public static void AddTransformPositionX(this Transform transform, float x) {
			Vector3 newPos = transform.position;
			newPos.x += x;
			transform.position = newPos;
		}

		public static void AddTransformPositionY(this Transform transform, float y) {
			Vector3 newPos = transform.position;
			newPos.y += y;
			transform.position = newPos;
		}

		public static void AddTransformPositionZ(this Transform transform, float z) {
			Vector3 newPos = transform.position;
			newPos.z += z;
			transform.position = newPos;
		}

	}
}
