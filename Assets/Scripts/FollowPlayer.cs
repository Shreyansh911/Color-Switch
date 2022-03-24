using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	[SerializeField] Transform _player;

	Player player;

    void Start()
    {
		player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
	{
		if (_player.position.y > transform.position.y)
		{
			transform.position = new Vector3(transform.position.x, _player.position.y, transform.position.z);
		}

		if(_player.position.y < transform.position.y - 6)
        {
			player.GameOver();
        }
	}
}
