//Desarrollado por: Yonny Florez.
//Fecha de Creación: 07/11/2005

using System;
using System.Collections;

namespace Componentes.BLL
{
	/// <summary>
	/// ESColeccionUsuario: Maneja objetos de tipo ESUsuario para su ordenación
	/// </summary>
	public class ESColeccionUsuario: ArrayList
	{
		public enum UsuarioCampos
		{
			Fecha,
			Codigo,
			Usuario,
			Nombre,
			Linea,
			Oficina,
			Estatus,
			Categoria
		}

		public ESColeccionUsuario()
		{
		}

		public void Ordenar(UsuarioCampos sortField, bool isAscending)
		{
			switch (sortField) 
			{
				case UsuarioCampos.Fecha:
					base.Sort(new Fecha());
					break;
				case UsuarioCampos.Codigo:
					base.Sort(new Codigo());
					break;
				case UsuarioCampos.Usuario:
					base.Sort(new Usuario());
					break;
				case UsuarioCampos.Nombre:
					base.Sort(new Nombre());
					break;
				case UsuarioCampos.Linea:
					base.Sort(new Linea());
					break;
				case UsuarioCampos.Oficina:
					base.Sort(new Oficina());
					break;
				case UsuarioCampos.Estatus:
					base.Sort(new Estatus());
					break;
				case UsuarioCampos.Categoria:
					base.Sort(new Categoria());
					break;
			}

			if (!isAscending) base.Reverse();
		}

		private sealed class Fecha : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.dttFechaCreacion.CompareTo(second.dttFechaCreacion);
			}
		}

		private sealed class Codigo : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.intCodStaff.CompareTo(second.intCodStaff);
			}
		}

		private sealed class Usuario : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strUsuario.CompareTo(second.strUsuario);
			}
		}

		private sealed class Nombre : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strNombreCorto.CompareTo(second.strNombreCorto);
			}
		}
	
		private sealed class Linea : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strLineaDepartamento.CompareTo(second.strLineaDepartamento);
			}
		}

		private sealed class Oficina : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strOficina.CompareTo(second.strOficina);
			}
		}

		private sealed class Estatus : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strEstatus.CompareTo(second.strEstatus);
			}
		}

		private sealed class Categoria : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESUsuario first = (ESUsuario) x;
				ESUsuario second = (ESUsuario) y;
				return first.strCategoria.CompareTo(second.strCategoria);
			}
		}
	}
}
