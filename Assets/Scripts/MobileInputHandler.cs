using UnityEngine;
using UnityEngine.EventSystems;

public class MobileInputHandler : MonoBehaviour
{
	private PlayerMovement player;

	void Start()
	{
		player = FindObjectOfType<PlayerMovement>();
	}

	void Update()
	{
#if UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x < Screen.width / 2)
				player.SetMoveInput(-1f);
			else
				player.SetMoveInput(1f);
		}
		else
		{
			player.SetMoveInput(0f);
		}
#endif
	}
}
