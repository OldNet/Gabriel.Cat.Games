/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 07/13/2015
 * Hora: 22:43
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Interaction logic for PintaMatriz.xaml
	/// </summary>
	public partial class PintaMatriz : Canvas
	{
		LlistaOrdenada<int,SolidColorBrush> coloresUsados;
		Color[,] matriz;
		public PintaMatriz()
		{
			
			coloresUsados = new LlistaOrdenada<int,SolidColorBrush>();
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public Color[,] Matriz {
			get {
				return matriz;
			}
			set {
				int colorInt;
				Line punto;

				Color[,] matrizAnt=matriz;
				double amplitud;
				double altura;
				matriz = value;
				
				amplitud=Width/matriz.GetLength(DimensionMatriz.X);
				altura=Height/matriz.GetLength(DimensionMatriz.Y);
				if(matrizAnt!=null&&(matriz.GetLength(DimensionMatriz.X)!=matrizAnt.GetLength(DimensionMatriz.X)||matriz.GetLength(DimensionMatriz.Y)!=matrizAnt.GetLength(DimensionMatriz.Y)))
				{
					matrizAnt=null;
					Children.Clear();
				}
				for (int y = 0, yFinal = matriz.GetLength(DimensionMatriz.Y); y < yFinal; y++)
					for (int x = 0, xFinal = matriz.GetLength(DimensionMatriz.X); x < xFinal; x++) {
					colorInt = matriz[x, y].ToArgb();
					if (!coloresUsados.Existeix(colorInt)) {
						coloresUsados.Afegir(colorInt, new SolidColorBrush(matriz[x, y]));
					}
					if(matrizAnt==null)
					{
						punto=new Line();
						punto.Fill=coloresUsados[colorInt];
						punto.Width=amplitud;
						punto.Height=altura;
						Children.Insert(xFinal*y+x,punto);
						Canvas.SetTop(punto, y);
						Canvas.SetLeft(punto, x);
					}
					else if(matrizAnt[x,y]!=matriz[x,y])
					{
						punto=new Line();
						punto.Fill=coloresUsados[colorInt];
						punto.Width=amplitud;
						punto.Height=altura;
						Children.RemoveAt(xFinal*y+x);
						Children.Insert(xFinal*y+x,punto);
						Canvas.SetTop(punto, y);
						Canvas.SetLeft(punto, x);
					}
				}
				
			}
		}
		

	}
}