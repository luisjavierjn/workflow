using System;

namespace Componentes.BLL.SE
{
	public class ESError
	{
		private string _strTitulo = string.Empty;
		private string _strDescripcion = string.Empty;
		private string _strDetalle = string.Empty;

		public string strTitulo
		{
			get { return _strTitulo; }
			set { _strTitulo = value; }
		}

		public string strDescripcion
		{
			get { return _strDescripcion; }
			set { _strDescripcion = value; }
		}

		public string strDetalle
		{
			get { return _strDetalle; }
			set { _strDetalle = value; }
		}

		public ESError()
		{
		}
	}
}
