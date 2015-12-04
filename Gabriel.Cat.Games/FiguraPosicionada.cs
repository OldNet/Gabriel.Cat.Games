/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 12/07/2015
 * Hora: 21:41
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
namespace Gabriel.Cat.Games
{
	public class FiguraPosicionada
	{
		Figura figura;

		PointZ posicion;

		//posicion de la figura en la figura Animada
		public FiguraPosicionada(PointZ posicion, Figura figura)
		{
			Figura = figura;
			Posicion = posicion;
		}

		public Figura Figura {
			get {
				return figura;
			}
			set {
				figura = value;
			}
		}

		public PointZ Posicion {
			get {
				return posicion;
			}
			set {
				posicion = value;
			}
		}

		public Pixel SelectPixel(PointZ externPoint)
		{
			PointZ internalPoint = new PointZ(externPoint.X - Posicion.X, externPoint.Y - Posicion.Y, externPoint.Z - Posicion.Z);
			Pixel selectedPixel = null;
			var figuraPixelada = Figura.GetEnumerator();
			while (selectedPixel == null && figuraPixelada.MoveNext()) {
				if (figuraPixelada.Current.Localizacion.Equals(internalPoint))
					selectedPixel = figuraPixelada.Current;
			}
			return selectedPixel;
		}
	}
}


