//Desarrollado por: Yonny Florez.
//Fecha de Creación: 12/01/2006

using System;
using System.Collections;

namespace Componentes.BLL.SE
{
	public class ESColeccionRol: ArrayList
	{
		public enum RolCampos
		{
			Numero,
			Rol,
			Descripcion
		}

		public ESColeccionRol()
		{
		}

		public void Ordenar(RolCampos sortField, bool isAscending)
		{
			switch (sortField) 
			{
				case RolCampos.Numero:
					base.Sort(new Numero());
					break;
				case RolCampos.Rol:
					base.Sort(new Rol());
					break;
				case RolCampos.Descripcion:
					base.Sort(new Descripcion());
					break;
			}

			if (!isAscending) base.Reverse();
		}

		private sealed class Numero : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESRol first = (ESRol) x;
				ESRol second = (ESRol) y;
				return first.shtRol.CompareTo(second.shtRol);
			}
		}

		private sealed class Rol : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESRol first = (ESRol) x;
				ESRol second = (ESRol) y;
				return first.strRol.CompareTo(second.strRol);
			}
		}

		private sealed class Descripcion : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESRol first = (ESRol) x;
				ESRol second = (ESRol) y;
				return first.strDescripcionRol.CompareTo(second.strDescripcionRol);
			}
		}
	}
}
