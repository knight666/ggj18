using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
	Left,
	Right
};

public class Pathing : MonoBehaviour
{
	public static Directions[][] m_paths = new Directions[3][] {
		new Directions[] { Directions.Right, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Right },
		new Directions[] { Directions.Right, Directions.Left, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Right, Directions.Right, Directions.Right },
		new Directions[] { Directions.Left, Directions.Right, Directions.Right, Directions.Right, Directions.Right, Directions.Left, Directions.Left, Directions.Left, Directions.Left }
	};
	public static List<Directions> m_currentPath = new List<Directions>(9);

	private static bool s_Initialized = false;

	public static void Initialize()
	{
		if (s_Initialized)
		{
			return;
		}

		s_Initialized = true;

		int pick = Random.Range(0, 2);
		Debug.Log("Picked path " + pick.ToString());
		m_currentPath.AddRange(m_paths[pick]);
	}
}
