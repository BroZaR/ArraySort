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
			view.EventInputManually += View_EventInputManually;
			view.EventInputFille += View_EventInputFille;
			view.EventInputRandom += View_EventInputRandom;
		}

		private void View_EventInputRandom(object sender, Common.Events.EventArgsRandom e)
		{
			throw new NotImplementedException();
		}

		private void View_EventInputFille(object sender, Common.Events.EventArgsFile e)
		{
			throw new NotImplementedException();
		}

		private void View_EventInputManually(object sender, Common.Events.EventArgsManually e)
		{
			throw new NotImplementedException();
		}
	}
}
