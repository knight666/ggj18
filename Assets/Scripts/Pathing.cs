using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing
{
	public enum Directions
	{
		Left,
		Right
	};

	public static Directions[][] m_paths = new Directions[3][] {
		new Directions[] { Directions.Right, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Right },
		new Directions[] { Directions.Right, Directions.Left, Directions.Right, Directions.Left, Directions.Left, Directions.Right, Directions.Right, Directions.Right, Directions.Right },
		new Directions[] { Directions.Left, Directions.Right, Directions.Right, Directions.Right, Directions.Right, Directions.Left, Directions.Left, Directions.Left, Directions.Left }
	};
	public static List<Directions> m_currentPath = new List<Directions>(9);

	public static void Initialize()
	{
		m_currentPath.AddRange(m_paths[0]);
	}
}
