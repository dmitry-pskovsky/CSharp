using System;
using Console.Nature;
using Console.Settings;
using Console.Statistics;
using Console.UI;
using Console.Utilities;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Console;
using System.Collections.Generic;
using Console.DisplayObjects;
	
public class ApplicationWindow : GameWindow
{
	private float pos;
	private GraphicShape shape, shape1;
	private DisplayObject parent;
	private SlotsRow slotsRow;
	
	public ApplicationWindow(int width, int height)
		: base(width, height)
	{	
		List<int> ls = new List<int>();

		slotsRow = new SlotsRow(10, 2, 0.5f);
		slotsRow.Position = new Vector2(-this.Width / 2, this.Height / 2);
		
		EssencesSource source = new EssencesSource();
		
		List<Vector2> points;
		List<Organism> organisms = new List<Organism>();
		
		for (int i = 0; i < 50; i++)
		{
			points = source.GenerateEssance();
			
			OrganismParameters parameters = new OrganismParameters(points);
			Organism organism = new Organism(parameters);
			organisms.Add(organism);
		}
		
		Statistics.WrightConsole();
		
		organisms.Sort(delegate(Organism organism1, Organism organism2)
		{
			return organism2.Square.CompareTo(organism1.Square);
		});
		
		for (int i = 0; i < 20; i++)
		{
			slotsRow.AddShape(organisms[i].GetDisplayObject());
		}
		
		//slotsRow.AddShape(organism.GetDisplayObject());
	}
	
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
	}
	
	protected override void OnUpdateFrame(FrameEventArgs e)
	{
		base.OnUpdateFrame(e);
	}
	
	protected override void OnRenderFrame(FrameEventArgs e)
	{
		base.OnRenderFrame(e);
		
		UpdateScreen();
		
		//parent.Position = new Vector2(pos+=0.5f, 0);
		DisplayObjectContainer.Update();

		this.SwapBuffers();
	}
	
	void UpdateScreen()
	{
		GL.Clear(ClearBufferMask.ColorBufferBit);
		GL.ClearColor(ApplicationConstants.BACKGROUND_COLOR);
		this.MakeCurrent();
		GL.MatrixMode(MatrixMode.Projection);
		GL.LoadIdentity();
		GL.Ortho((-this.Width / 2), this.Width / 2, (-this.Height / 2), (this.Height / 2), -1, 1);
 		GL.Viewport(0, 0, this.Width, this.Height);
	}
	

}
