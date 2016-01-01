/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 12/07/2015
 * Hora: 21:41
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
	/// Description of Figura.
	/// </summary>
	public class Figura:IEnumerable<Pixel>,IClauUnicaPerObjecte
	{
		static GeneradorHex generadorId = new GeneradorHex();
		string idUnico;
		protected Llista<Pixel> pixels;
		//posicion de los pixeles en la figura
		public Figura()
		{
			pixels = new Llista<Pixel>();
			idUnico = generadorId.Siguiente();
		}
		public Figura(string idUnico, IEnumerable<Pixel> pixels)
			: this()
		{
			IdUnico = idUnico;
			Afegir(pixels);
		}

		public string IdUnico {
			get {
				return ToString() + ":" + idUnico;
			}
			set {
				if (!value.Contains(ToString()))
					throw new Exception("El id no se corresponde a una " + ToString());
				idUnico = value.Split(':')[1];
			}
		}

		public Pixel[,] PixelsXY {
			get {
				int xMax = 0;
				int yMax = 0;
				pixels.Ordena();
				Pixel[,] matriz;
				for (int i = 0; i < pixels.Count; i++) {
					if (pixels[i].Localizacion.Y > yMax)
						yMax = pixels[i].Localizacion.Y;
					if (pixels[i].Localizacion.X > xMax)
						xMax = pixels[i].Localizacion.X;
				}
				matriz = new Pixel[xMax, yMax];
				for (int i = pixels.Count - 1; i > 0; i--)//va de atras a alante para poner los pixeles que se ven :D
					matriz[pixels[i].Localizacion.X, pixels[i].Localizacion.Y] = pixels[i];
				return matriz;
				
			}
			set {
				pixels.Buida();
				for (int y = 0, yFinal = value.GetLength(DimensionMatriz.Y); y < yFinal; y++)
					for (int x = 0, xFinal = value.GetLength(DimensionMatriz.X); x < xFinal; x++)
						pixels.Afegir(value[x, y]);
				
			}
		}
		public Pixel[,,] PixelsXYZ {
			get {
				int xMax = 0;
				int yMax = 0;
				int zMax = 0;
				Pixel[,,] matriz;
				for (int i = 0; i < pixels.Count; i++) {
					if (pixels[i].Localizacion.Y > yMax)
						yMax = pixels[i].Localizacion.Y;
					if (pixels[i].Localizacion.X > xMax)
						xMax = pixels[i].Localizacion.X;
					if (pixels[i].Localizacion.Z > zMax)
						zMax = pixels[i].Localizacion.Z;
				}
				matriz = new Pixel[xMax, yMax, zMax];
				for (int i = 0; i < pixels.Count; i++)
					matriz[pixels[i].Localizacion.X, pixels[i].Localizacion.Y, pixels[i].Localizacion.Z] = pixels[i];
				return matriz;
				
			}
			set {
				pixels.Buida();
				for (int z = 0, zFinal = value.GetLength(DimensionMatriz.Z); z < zFinal; z++)
					for (int y = 0, yFinal = value.GetLength(DimensionMatriz.Y); y < yFinal; y++)
						for (int x = 0, xFinal = value.GetLength(DimensionMatriz.X); x < xFinal; x++)
							pixels.Afegir(value[x, y, z]);
				
			}
		}
		public int Amplitud {
			get {
				int xMax = 0;
				for (int i = 0; i < pixels.Count; i++) {
					if (pixels[i].Localizacion.X > xMax)
						xMax = pixels[i].Localizacion.X;
				}
				return xMax;
			}
		}
		public int Altura {
			get {
				
				int yMax = 0;

				for (int i = 0; i < pixels.Count; i++) {
					if (pixels[i].Localizacion.Y > yMax)
						yMax = pixels[i].Localizacion.Y;
				}
				return yMax;
			}
		}
		public int Fondo {
			get {

				int zMax = 0;

				for (int i = 0; i < pixels.Count; i++) {
					if (pixels[i].Localizacion.Z > zMax)
						zMax = pixels[i].Localizacion.Z;
				}
				return zMax;
			}
		}
		public void Afegir(IEnumerable<Pixel> pixelsFigura)
		{
			pixels.AfegirMolts(pixelsFigura);
		}
		public void Afegir(Pixel pixelFigura)
		{
			pixels.Afegir(pixelFigura);
		}
		public void Treu(PointZ localitzacio)
		{
			int pos = 0;
			bool trobat = false;
			while (pos < pixels.Count && !trobat) {
				if (pixels[pos].Localizacion.Equals(localitzacio))
					trobat = true;
				else
					pos++;
			}
			pixels.Elimina(pos);
		}
		public void Treu(Pixel pixel)
		{
			pixels.Elimina(pixel);
		}
		public void SaveFile(string path)
		{
			if (!System.IO.Path.GetExtension(path).Contains("png"))
				path += ".png";
			PixelsXY.ToBitmap().Save(path, System.Drawing.Imaging.ImageFormat.Png);
		}
		public void LoadFile(string path)
		{
			Load(new Bitmap(path));
		}
		public void Load(Bitmap bmp)
		{
			pixels.Buida();
			Pixel[,] matriu = bmp.ToPixelMatriz();
			for(int y=0;y<matriu.GetLength(DimensionMatriz.Y);y++)
				for(int x=0;x<matriu.GetLength(DimensionMatriz.X);x++)
					if(matriu[x,y]!=null)
						pixels.Afegir(matriu[x,y]);

		}
		#region IEnumerable implementation

		public IEnumerator<Pixel> GetEnumerator()
		{
			return pixels.GetEnumerator();
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region IClauUnicaPerObjecte implementation

		public IComparable Clau()
		{
			return IdUnico;
		}

		#endregion
		public static void UltimoId(string idHex)
		{
			generadorId.Reset(idHex);
		}
		public override string ToString()
		{
			return "Figura";
		}
	}
}
