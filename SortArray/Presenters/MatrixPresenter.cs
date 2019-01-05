using SortArray.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Presenters
{
	public class MatrixPresenter
	{
		private IModel model;
		private IView view;

		public MatrixPresenter(IModel _model, IView _view) {
			model = _model;
			view = _view;
		}

		public void Start() {
			view.EnterLine += View_EnterLine;
			view.Show();
		}

		private void View_EnterLine(string str)
		{
			Console.WriteLine(str);
		}
	}
}
