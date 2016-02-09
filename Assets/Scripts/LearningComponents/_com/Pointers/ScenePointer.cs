using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LearningComponents
{
	public class ScenePointer : MonoBehaviour
	{
		private readonly Vector2 Point1 = new Vector2(0.0f, 1.0f);
		private readonly Vector2 Point2 = new Vector2(2.0f, 0.00f);

		[SerializeField] private NumberPointerView _number;
		[SerializeField] private List<LinePointerView> _lines = new List<LinePointerView>();
		private Transform _cachedTransform;

		private void Start()
		{
			_cachedTransform = transform;
		}

		private void Update()
		{
			float cache = (_cachedTransform.transform.position.z - Point1.x) * (Point2.y - Point1.y) / (Point2.x - Point1.x) + Point1.y;
			float alpha = Mathf.Clamp(cache, 0.0f, 1.0f);

			_number.ChangeAlpha(alpha);
			_number.OnUpdate();
			_lines.ForEach( a => a.ChangeAlpha(alpha) );
			_lines.ForEach( a => a.OnUpdate() );
		}
	}
}
