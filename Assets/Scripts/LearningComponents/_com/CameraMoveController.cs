using UnityEngine;
using System.Collections;

namespace LearningComponents
{
	public class CameraMoveController : MonoBehaviour
	{
		[SerializeField] private float _keyboardRotateSpeed = 2.0f;
		[SerializeField] private float _mouseRotateSpeed = 0.5f;
		private Transform _cachedTransform;
		private Vector3 _cachedMousePosition;

		private void Start()
		{
			_cachedTransform = transform;
		}

		private void Update()
		{
			if(!MouseInput())
			{
				KeyboardInput();
			}
		}

		private bool MouseInput()
		{
			if(Input.GetMouseButtonDown(1))
			{
				_cachedMousePosition = Input.mousePosition;
			}
			if(Input.GetMouseButton(1))
			{
				RotateCamera(new Vector2(- (Input.mousePosition.y - _cachedMousePosition.y),
				                         Input.mousePosition.x - _cachedMousePosition.x) * _mouseRotateSpeed);
				_cachedMousePosition = Input.mousePosition;
				return true;
			}
			return false;
		}

		private void KeyboardInput()
		{
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				RotateCamera(new Vector2(0.0f, _keyboardRotateSpeed));
			}
			if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				RotateCamera(new Vector2(0.0f, - _keyboardRotateSpeed));
			}
			if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				RotateCamera(new Vector2(_keyboardRotateSpeed, 0.0f));
			}
			if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				RotateCamera(new Vector2(- _keyboardRotateSpeed, 0.0f));
			}
		}

		private void RotateCamera(Vector2 angle)
		{
			_cachedTransform.rotation = Quaternion.Euler(new Vector3(Mathf.Clamp(_cachedTransform.rotation.eulerAngles.x + angle.x, 0.0f, 60.0f),
			                                                         			 _cachedTransform.rotation.eulerAngles.y + angle.y,
			                                                         			 _cachedTransform.rotation.eulerAngles.z));
		}
	}
}
