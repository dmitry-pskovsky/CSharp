using System;
using System.Globalization;
using System.Drawing;
using Console.Settings;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Collections.Generic;

namespace Console.Utilities
{
	public class GraphicUtilities
	{
		public GraphicUtilities()
		{
			
		}
		
		static public Color GetColorFromHEX(String colorcode)
		{
			int argb = Int32.Parse(colorcode.Replace("#", ""), NumberStyles.HexNumber);
			Color color = Color.FromArgb(argb);
			
			return color;
		}
		
		static void ApplyScale(List<Vector2> points, out List<Vector2> scaledPoints, float scale)
		{
			int count = points.Count;
			scaledPoints = new List<Vector2>();
			
			for (int i = 0; i < count; i++)
			{
				scaledPoints.Add(new Vector2(points[i].X * scale, points[i].Y * scale));
			}
		}
		
		static void DrawLittleScale(List<Vector2> points, Vector2 position, float scale)
		{
			ApplyScale(points, out points, scale);
			
			int length = points.Count;
			int i;
			
			DrawLittleCircle(2f, points[0], position);
			for (i = 0; i < length - 1; i++)
			{
				DrawLine(points[i], points[i + 1], position);
				DrawLittleCircle(2f, points[i], position);
			}
			DrawLine(points[i], points[0], position);
			DrawLittleCircle(2f, points[i], position);
		}
		
		static void DrawBigScale(List<Vector2> points, Vector2 position, float scale)
		{
			ApplyScale(points, out points, scale);
			
			int length = points.Count;
			int i;
			DrawPointCircle(3f, points[0], position);
			for (i = 0; i < length - 1; i++)
			{
				DrawLine(points[i], points[i + 1], position);
				DrawPointCircle(3f, points[i], position);
			}
			DrawLine(points[i], points[0], position);
			DrawPointCircle(3f, points[i], position);
		}
		
		static void DrawNormalScale(List<Vector2> points, Vector2 position, float scale)
		{
			int length = points.Count;
			int i;
			DrawPointCircle(3f, points[0], position);
			for (i = 0; i < length - 1; i++)
			{
				DrawLine(points[i], points[i + 1], position);
				DrawPointCircle(3f, points[i], position);
			}
			DrawLine(points[i], points[0], position);
			DrawPointCircle(3f, points[i], position);
		}
		
		static public void DrawShape(List<Vector2> points, Vector2 position, float scale = 1.0f)
		{
			if (scale < 1.0f)
			{
				DrawLittleScale(points, position, scale);
			}
			else if (scale > 1.0f)
			{
				DrawBigScale(points, position, scale);
			}
			else
			{
				DrawNormalScale(points, position, scale);
			}
		}
		
		static public void DrawLittleCircle(float radius, Vector2 position, Vector2 globalPosition)
		{
			GL.Color3(GraphicUtilities.GetColorFromHEX("#ffffff"));
		
			GL.Begin(BeginMode.TriangleFan);
			for (int i = 0; i < 370; i+=40)
			{
				double degInRad = i * 3.1416/180;
				GL.Vertex2(Math.Cos(degInRad) * radius + position.X + globalPosition.X, Math.Sin(degInRad) * radius + position.Y + globalPosition.Y);
			}
			GL.End();
		}
		
		static public void DrawPointCircle(float radius, Vector2 position, Vector2 globalPosition)
		{
			GL.Color3(GraphicUtilities.GetColorFromHEX("#bcea64"));
			GL.Begin(BeginMode.QuadStrip);

			int i;
			for (i = 0; i < 370; i+=40)
			{
				double degInRad = i * 3.1416/180;
				GL.Vertex2(Math.Cos(degInRad) * radius + position.X + globalPosition.X, Math.Sin(degInRad) * radius + position.Y + globalPosition.Y);
				GL.Vertex2(Math.Cos(degInRad) * (radius + 2f) + position.X + globalPosition.X, Math.Sin(degInRad) * (radius + 2f) + position.Y + globalPosition.Y);
			}
			
			GL.End();
			
			GL.Color3(ApplicationConstants.BACKGROUND_COLOR);
			GL.Begin(BeginMode.TriangleFan);
			for (i = 0; i < 370; i+=40)
			{
				double degInRad = i * 3.1416/180;
				GL.Vertex2(Math.Cos(degInRad) * radius + position.X + globalPosition.X, Math.Sin(degInRad) * radius + position.Y + globalPosition.Y);
			}
			GL.End();
		}
		
		static public void DrawLine(Vector2 startPos, Vector2 endPos, Vector2 position, Color color)
		{
			startPos += position;
			endPos += position;
			
			GL.LineWidth(1.5f);
			GL.Enable(EnableCap.LineSmooth);
			GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(color);
			GL.Vertex2(startPos);
			GL.Color3(color);
			GL.Vertex2(endPos);
			GL.End();
		}
		
		static public void DrawLine(Vector2 startPos, Vector2 endPos, Vector2 position, Color color, float width)
		{
			startPos += position;
			endPos += position;
			
			GL.LineWidth(width);
			GL.Enable(EnableCap.LineSmooth);
			GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(color);
			GL.Vertex2(startPos);
			GL.Color3(color);
			GL.Vertex2(endPos);
			GL.End();
		}
		
		static public void DrawLine(Vector2 startPos, Vector2 endPos, Vector2 position)
    	{
			startPos += position;
			endPos += position;
			
			GL.LineWidth(1.5f);
			GL.Enable(EnableCap.LineSmooth);
			GL.Hint(HintTarget.LineSmoothHint, HintMode.Nicest);
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(GraphicUtilities.GetColorFromHEX("#e92066"));
			GL.Vertex2(startPos);
			GL.Color3(GraphicUtilities.GetColorFromHEX("#e92066"));
			GL.Vertex2(endPos);
			GL.End();
    	}
	}
}
