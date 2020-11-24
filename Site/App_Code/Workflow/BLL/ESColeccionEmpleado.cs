//Desarrollado por: Jhanmara Duque
//Fecha de Creación: 06/05/2005
using System;
using System.Collections;

namespace Componentes.BLL
{
	/// <summary>
	/// Clase que contiene la colección de campos del empleado.
	/// Su principal funcionalidad es realizar el ordenamiento de manera 
	/// ascendente o descendete.
	/// </summary>
	public class ESColeccionEmpleado : ArrayList
	{
		public enum EmpleadoCampos
		{
			Nombre,
			Codigo,
			Departamento,
			Categoria,
			FechaIngreso,
			Email
		}

		public ESColeccionEmpleado()
		{
		}

		public void Ordenar(EmpleadoCampos sortField, bool isAscending)
		{
			
			switch (sortField) 
			{
				case EmpleadoCampos.Nombre:
					base.Sort(new Nombre());
					break;
				case EmpleadoCampos.Codigo:
					base.Sort(new Codigo());
					break;
				case EmpleadoCampos.Departamento:
					base.Sort(new Departamento());
					break;
				case EmpleadoCampos.Categoria:
					base.Sort(new Categoria());
					break;
				case EmpleadoCampos.FechaIngreso:
					base.Sort(new FechaIngreso());
					break;
				case EmpleadoCampos.Email:
					base.Sort(new Email());
					break;
			}
			if (!isAscending) base.Reverse();			
		}

		private sealed class Nombre : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.strNombreLargo.CompareTo(second.strNombreLargo);
			}
		}

		private sealed class Codigo : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.strCodStaff.CompareTo(second.strCodStaff);
			}
		}

		private sealed class Departamento : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.strDepartamento.CompareTo(second.strDepartamento);
			}
		}

		private sealed class Categoria : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.strCategoria.CompareTo(second.strCategoria);
			}
		}

		private sealed class FechaIngreso : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.dttFechaIngreso.CompareTo(second.dttFechaIngreso);
			}
		}

		private sealed class Email : IComparer 
		{
			public int Compare(object x, object y)
			{
				ESEmpleado first = (ESEmpleado) x;
				ESEmpleado second = (ESEmpleado) y;
				return first.strEmail.CompareTo(second.strEmail);
			}
		}


	}
}
