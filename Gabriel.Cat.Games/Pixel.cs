/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 12/07/2015
 * Hora: 21:38
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using Gabriel.Cat;
namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Description of Pixel.
	/// </summary>
	public class Pixel:IClauUnicaPerObjecte
	{
		PointZ localizacion;
		Color colorPixel;
		public Pixel()
			: this(Color.White,new PointZ())
		{

		}
		public Pixel(Color color, PointZ posicion)
		{
			localizacion = posicion;
			colorPixel = color;
		}

		public PointZ Localizacion {
			get {
				return localizacion;
			}
			set {
				localizacion = value;
			}
		}

		public Color ColorPixel {
			get {
				return colorPixel;
			}
			set {
				colorPixel = value;
			}
		}

		#region IClauUnicaPerObjecte implementation

		public IComparable Clau()
		{
			return localizacion;
		}

		#endregion
	}
}
