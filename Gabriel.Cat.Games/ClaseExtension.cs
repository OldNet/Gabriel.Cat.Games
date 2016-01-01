/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 21/07/2015
 * Hora: 15:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using Gabriel.Cat.Extension;
namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Description of ClaseExtension.
	/// </summary>
	public static  class ExtensionClass
	{
		public static Color[,] ToColorMatriz(this Pixel[,] matriuPixelada)
		{
			System.Drawing.Color[,] colores = new System.Drawing.Color[matriuPixelada.GetLength(DimensionMatriz.X), matriuPixelada.GetLength(DimensionMatriz.Y)];
			for (int y = 0; y < matriuPixelada.GetLength(DimensionMatriz.Y); y++)
				for (int x = 0; x < matriuPixelada.GetLength(DimensionMatriz.X); x++)
					if (matriuPixelada[x, y] != null)
						colores[x, y] = matriuPixelada[x, y].ColorPixel;
					else
						colores[x, y] = Color.Transparent;
			return colores;
		}
		public static Bitmap ToBitmap(this Pixel[,] matriz)
		{
			return matriz.ToColorMatriz().ToBitmap();
		}
		public static Pixel[,] ToPixelMatriz(this Bitmap bmp)
		{
			return bmp.ToColorMatriz().ToPixelMatriz();
		}
		public static Pixel[,] ToPixelMatriz(this Color[,] colorMatriu)
		{
			Pixel[,] matriu = new Pixel[colorMatriu.GetLength(DimensionMatriz.X), colorMatriu.GetLength(DimensionMatriz.X)];
			for (int y = 0; y < matriu.GetLength(DimensionMatriz.Y); y++)
				for (int x = 0; x < matriu.GetLength(DimensionMatriz.X); x++)
					if (colorMatriu[x, y] != Color.Transparent)
						matriu[x, y] = new Pixel(colorMatriu[x, y], new PointZ(x, y, 0));
			return matriu;
		}
	}
}
