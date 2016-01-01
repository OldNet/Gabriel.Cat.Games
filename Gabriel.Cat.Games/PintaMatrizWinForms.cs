/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 30/06/2015
 * Hora: 20:40
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Gabriel.Cat;
using System.Threading;
using System.Drawing.Drawing2D;
using Gabriel.Cat.Extension;

namespace Gabriel.Cat.Games.WinForms
{
	/// <summary>
	/// Description of PintaMatriz.
	/// Es una clase que tiene que pintar matrices muy rapido lo mas rapido que sea posible
	/// </summary>
	public partial class PintaMatriz : UserControl
	{
		LlistaOrdenada<int,Pen> coloresUsados;
		Color[,] matriz;
		Pen[,] matrizTratada;
		public PintaMatriz()
		{
			coloresUsados = new LlistaOrdenada<int, Pen>();
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			matriz = new Color[6400, 3600];
			for (int y = 0; y < matriz.GetLength(DimensionMatriz.Y); y++)
				for (int x = 0; x < matriz.GetLength(DimensionMatriz.X); x++)
					matriz[x, y] = Color.PaleVioletRed;
			Matriz = matriz;
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
		}

		public Color[,] Matriz {
			get {
				return matriz;
			}
			set {
				int colorInt;
				matriz = value;
				matrizTratada = new Pen[matriz.GetLength(DimensionMatriz.X), matriz.GetLength(DimensionMatriz.Y)];//asi el new lo hace solo una sola vez :D y no cada onPaint
				for (int y = 0, yFinal = matriz.GetLength(DimensionMatriz.Y); y < yFinal; y++)
					for (int x = 0, xFinal = matriz.GetLength(DimensionMatriz.X); x < xFinal; x++) {
						colorInt = matriz[x, y].ToArgb();
						if (!coloresUsados.Existeix(colorInt)) {
							coloresUsados.Afegir(colorInt, new Pen(matriz[x, y]));
						}
						matrizTratada[x, y] = coloresUsados[colorInt];
					}
				Refresh();
			}
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (matriz != null) {
				for (int y = 0, yFinal = matriz.GetLength(DimensionMatriz.Y); y < yFinal; y++)
					for (int x = 0, xFinal = matriz.GetLength(DimensionMatriz.X); x < xFinal; x++)
						e.Graphics.DrawLine(matrizTratada[x, y], x, y, x + 1, y);
			}
		}
	}
}
