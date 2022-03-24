using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRotater : MonoBehaviour
{
	[SerializeField] float _speed = 100;

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0, 0, _speed * Time.deltaTime);
	}
}
