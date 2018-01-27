using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
	public Material m_material;
	private Vector3 m_startVertex = new Vector3(0, 0, 0);
	private Vector3 m_cursorPosition;

	void Update()
	{
		m_cursorPosition = Input.mousePosition;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_startVertex = new Vector3(m_cursorPosition.x / Screen.width, m_cursorPosition.y / Screen.height, 0);
		}
	}

	void OnPostRender()
	{
		if (!m_material)
		{
			Debug.LogError("Please Assign a material on the inspector");
			return;
		}

		GL.PushMatrix();
		m_material.SetPass(0);
		GL.LoadOrtho();
		GL.Begin(GL.LINES);
		GL.Color(Color.red);
		GL.Vertex(m_startVertex);
		GL.Vertex(new Vector3(m_cursorPosition.x / Screen.width, m_cursorPosition.y / Screen.height, 0));
		GL.End();
		GL.PopMatrix();
	}
}
