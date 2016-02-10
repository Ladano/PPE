using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	[ExecuteInEditMode]
	public class LineWpGizmos : MonoBehaviour
	{
		#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawSphere(transform.position, 0.2f);
		}
		#endif
	}
}
