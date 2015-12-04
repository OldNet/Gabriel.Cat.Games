/*
 * Creado por SharpDevelop.
 * Usuario: Gabriel
 * Fecha: 13/07/2015
 * Hora: 21:20
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
namespace Gabriel.Cat.Games
{
	public static class ExtensionWpf
	{
		public static int ToArgb(this Color color)
		{
			byte[] argb =  {
				color.A,
				color.R,
				color.G,
				color.B
			};
			return Serializar.ToInt(argb);
		}
	}
}

