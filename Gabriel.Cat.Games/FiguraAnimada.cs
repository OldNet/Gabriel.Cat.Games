/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 13/07/2015
 * Hora: 0:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace Gabriel.Cat.Games
{
	/// <summary>
	/// Description of FiguraAnimada.
	/// </summary>
	public class FiguraAnimada:Figura
	{
		Llista<Llista<Pixel>> fotogramas;
		int fotogramaActual;
		public FiguraAnimada()
			: base()
		{
			fotogramas = new Llista<Llista<Pixel>>();
			fotogramaActual = 1;
			fotogramas.Afegir(base.pixels);
			
		}
		public int FotogramaActual {
			get{ return fotogramaActual; }
			set {
				if (value >= fotogramas.Count)
					value = fotogramas.Count - 1;
				else if (value < 0)
					value = 0;
				fotogramaActual = value;
				base.pixels = fotogramas[fotogramaActual];
				
			}
			
		}
		public void AñadirFotograma()
		{
			fotogramas.Afegir(new Llista<Pixel>());
		}
		public void AñadirFotograma(IEnumerable<Pixel> pixelesFotograma)
		{
			AñadirFotograma();
			fotogramas[fotogramas.Count - 1].AfegirMolts(pixelesFotograma);
		}
		public bool EliminaFotograma(int posicion)
		{
			bool paEliminar = fotogramas.Count > posicion && posicion > 0;
			if (paEliminar)
				fotogramas.Elimina(posicion);
			FotogramaActual = FotogramaActual;
			return paEliminar;
			
		}
		public override string ToString()
		{
			return "FiguraAnimada";
		}


	}
}
