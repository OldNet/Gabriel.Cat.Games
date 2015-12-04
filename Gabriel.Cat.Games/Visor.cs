/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 12/07/2015
 * Hora: 23:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Description of Visor.
	/// </summary>
	public class Visor:IClauUnicaPerObjecte
	{
		PointZ posicion;
		int amplitud;
		int altura;
		Llista<Mapa> mundo;
		public Visor()
			: this(1, 1)
		{
			
		}
		public Visor(int amplitud, int altura)
		{
			Amplitud = amplitud;
			Altura = altura;
			mundo = new Llista<Mapa>();
			posicion = new PointZ();
		}
		public Visor(IEnumerable<Mapa> mundo, int amplitud, int altura)
			: this(amplitud, altura)
		{
			Mundo.AfegirMolts(mundo);
		}

		public PointZ Posicion {
			get {
				return posicion;
			}
			set {
				posicion = value;
			}
		}
		public int Amplitud {
			get {
				return amplitud;
			}
			set {
				amplitud = value;
			}
		}

		public int Altura {
			get {
				return altura;
			}
			set {
				altura = value;
			}
		}

		public Llista<Mapa> Mundo {
			get {
				return mundo;
			}
		}
		public Color[,] PixelsXY {
			get {
				Color[,] visor = new Color[amplitud, altura];
				Rectangle rctVisor = new Rectangle(Posicion.X, Posicion.Y, Amplitud, Altura);
				LlistaOrdenada<PointZ,Color[,]> mapasVistos = new LlistaOrdenada<PointZ, Color[,]>();
				Pila<KeyValuePair<PointZ,Color[,]>> mapasAPoner = new Pila<KeyValuePair<PointZ, Color[,]>>();
				int yAbsVisor = Posicion.Y, yAbsFinalVisor = yAbsVisor + Altura, xAbsVisor = Posicion.X, xAbsFinalVisor = xAbsVisor + Amplitud;
				int yAbs, yAbsFinal, xAbs, xAbsFinal;
				//pongo los mapas que se pueden ver
				for (int i = 0; i < mundo.Count; i++) {
					if (rctVisor.IntersectsWith(mundo[i].RectanguloMapa()))
						mapasVistos.Afegir(mundo[i].Localizacion, mundo[i].PixelsXY);
				}
				mapasAPoner.Push(mapasVistos);
				//pongo en la matriz los pixeles que toquen...
				foreach (KeyValuePair<PointZ,Color[,]> parteMapa in mapasAPoner) {
					yAbs = parteMapa.Key.Y;
					xAbs = parteMapa.Key.X;
					yAbsFinal = yAbs + parteMapa.Value.GetLength(DimensionMatriz.Y);
					xAbsFinal = xAbs + parteMapa.Value.GetLength(DimensionMatriz.X);
					//mirar que este bien!! por acabar....no puedo pensar xD
					for (int y = yAbs - yAbsVisor, yFinal = yAbsFinal - yAbsFinalVisor; y < yFinal; y++)//hago el rectangulo que seria
						for (int x = xAbs - xAbsVisor, xFinal = xAbsFinal - xAbsFinalVisor; x < xFinal; x++) {
						//pongo los colores en el visor en su posicion
						
						}
				}
				return visor;
				
			}
		}
		
		#region IClauUnicaPerObjecte implementation
		public IComparable Clau()
		{
			return posicion;
		}
		#endregion
	}
}
