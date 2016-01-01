/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 12/07/2015
 * Hora: 22:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using Gabriel.Cat.Extension;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Description of Mapa.
	/// </summary>
	public class Mapa:IEnumerable<FiguraPosicionada>,IClauUnicaPerObjecte
	{
		string idUnico;
		static GeneradorHex genId=new GeneradorHex();
		PointZ localizacion;
		Llista<FiguraPosicionada> figuras;
		public Mapa()
		{
			figuras = new Llista<FiguraPosicionada>();
			idUnico=genId.Siguiente();
		}
		public Mapa(PointZ posicion, IEnumerable<FiguraPosicionada> figuras)
			: this()
		{
			Localizacion = posicion;
			this.Figuras.AfegirMolts(figuras);
		}
		public PointZ Localizacion {
			get {
				return localizacion;
			}
			set {
				if (value == null)
					value = new PointZ();
				localizacion = value;
			}
		}

		public string IdUnico {
			get {
				return ToString()+":"+idUnico;
			}
			set {
				if (!value.Contains(ToString()))
					throw new Exception("El id no se corresponde a una "+ToString());
				idUnico = value.Split(':')[1];
			}
		}

		public Llista<FiguraPosicionada> Figuras {
			get {
				return figuras;
			}
		}


		public Color[,] PixelsXY {
			get {
				LlistaOrdenada<PointZ,Pixel[,]> figurasTratadas = new LlistaOrdenada<PointZ, Pixel[,]>();
				Color[,] pixels;
				Pila<KeyValuePair<PointZ,Pixel[,]>> mapa = new Pila<KeyValuePair<PointZ, Pixel[,]>>();
				int xMax = 0, yMax = 0, contador = 0;
				for (int i = 0; i < figuras.Count; i++)
					figurasTratadas.Afegir(figuras[i].Posicion, figuras[i].Figura.PixelsXY);
				
				for (IEnumerator<KeyValuePair<PointZ,Pixel[,]>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,Pixel[,]> figura = i.Current;
					if (figura.Key.X + figura.Value.GetLength(DimensionMatriz.X) > xMax)
						xMax = figura.Key.X + figura.Value.GetLength(DimensionMatriz.X);
					if (figura.Key.Y + figura.Value.GetLength(DimensionMatriz.Y) > yMax)
						yMax = figura.Key.Y + figura.Value.GetLength(DimensionMatriz.Y);
					contador++;
					mapa.Push(figura);
				}
				pixels = new Color[xMax, yMax];
				
				for (IEnumerator<KeyValuePair<PointZ,Pixel[,]>> i = mapa.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,Pixel[,]> figura = i.Current;
					for (int y = 0, yFinal = figura.Value.GetLength(DimensionMatriz.Y); y < yFinal; y++)
						for (int x = 0, xFinal = figura.Value.GetLength(DimensionMatriz.X); x < xFinal; x++)
							pixels[figura.Key.X + x, figura.Key.Y + y] = figura.Value[x, y].ColorPixel;
				}
				return pixels;
			}
		}
		public Color[,,] PixelsXYZ {
			get {
				LlistaOrdenada<PointZ,Pixel[,,]> figurasTratadas = new LlistaOrdenada<PointZ, Pixel[,,]>();
				Color[,,] pixels;
				int xMax = 0, yMax = 0, zMax = 0, contador = 0;
				for (int i = 0; i < figuras.Count; i++)
					figurasTratadas.Afegir(figuras[i].Posicion, figuras[i].Figura.PixelsXYZ);
				
				for (IEnumerator<KeyValuePair<PointZ,Pixel[,,]>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,Pixel[,,]> figura = i.Current;
					
					if (figura.Key.X + figura.Value.GetLength(DimensionMatriz.X) > xMax)
						xMax = figura.Key.X + figura.Value.GetLength(DimensionMatriz.X);
					if (figura.Key.Y + figura.Value.GetLength(DimensionMatriz.Y) > yMax)
						yMax = figura.Key.Y + figura.Value.GetLength(DimensionMatriz.Y);
					if (figura.Key.Z + figura.Value.GetLength(DimensionMatriz.Z) > zMax)
						zMax = figura.Key.Z + figura.Value.GetLength(DimensionMatriz.Z);
					contador++;

				}
				pixels = new Color[xMax, yMax, zMax];
				
				for (IEnumerator<KeyValuePair<PointZ,Pixel[,,]>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,Pixel[,,]> figura = i.Current;
					for (int z = 0, zFinal = figura.Value.GetLength(DimensionMatriz.Z); z < zFinal; z++)
						for (int y = 0, yFinal = figura.Value.GetLength(DimensionMatriz.Y); y < yFinal; y++)
							for (int x = 0, xFinal = figura.Value.GetLength(DimensionMatriz.X); x < xFinal; x++)
								pixels[figura.Key.X + x, figura.Key.Y + y, figura.Key.Z + z] = figura.Value[x, y, z].ColorPixel;
				}
				return pixels;
			}
		}
		public int Amplitud {
			get {
				LlistaOrdenada<PointZ,int> figurasTratadas = new LlistaOrdenada<PointZ, int>();
				int xMax = 0, contador = 0;
				for (int i = 0; i < figuras.Count; i++)
					figurasTratadas.Afegir(figuras[i].Posicion, figuras[i].Figura.Amplitud);
				
				for (IEnumerator<KeyValuePair<PointZ,int>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,int> figura = i.Current;
					
					if (figura.Key.X + figura.Value > xMax)
						xMax = figura.Key.X + figura.Value;

					contador++;

				}
				return xMax;
			}
		}
		public int Altura {
			get {
				LlistaOrdenada<PointZ,int> figurasTratadas = new LlistaOrdenada<PointZ, int>();
				int yMax = 0, contador = 0;
				for (int i = 0; i < figuras.Count; i++)
					figurasTratadas.Afegir(figuras[i].Posicion, figuras[i].Figura.Altura);
				
				for (IEnumerator<KeyValuePair<PointZ,int>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,int> figura = i.Current;
					
					if (figura.Key.Y+ figura.Value > yMax)
						yMax = figura.Key.Y + figura.Value;

					contador++;

				}
				return yMax;
			}
		}
		public int Fondo {
			get {
				LlistaOrdenada<PointZ,int> figurasTratadas = new LlistaOrdenada<PointZ, int>();
				int zMax = 0, contador = 0;
				for (int i = 0; i < figuras.Count; i++)
					figurasTratadas.Afegir(figuras[i].Posicion, figuras[i].Figura.Fondo);
				
				for (IEnumerator<KeyValuePair<PointZ,int>> i = figurasTratadas.GetEnumerator(); i.MoveNext();) {
					KeyValuePair<PointZ,int> figura = i.Current;
					
					if (figura.Key.Z + figura.Value > zMax)
						zMax = figura.Key.Z + figura.Value;

					contador++;

				}
				return zMax;
			}
		}
		public Rectangle RectanguloMapa()
		{
			return new Rectangle(localizacion.X,localizacion.Y,Amplitud,Altura);
		}
		public Color[,] Area(PointZ esquinaSuperiorIzquierda,int amplitud,int altura)
		{
			Color[,] area=new Color[amplitud,altura];
			return area;
		}
		#region IClauUnicaPerObjecte implementation
		public IComparable Clau()
		{
			return Localizacion;
		}
		#endregion
		#region IEnumerable implementation

		public IEnumerator<FiguraPosicionada> GetEnumerator()
		{
			return figuras.GetEnumerator();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
		public override string ToString()
		{
			return "Mapa";
		}
	}
}
