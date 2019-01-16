using Common.Inputs;
using Common.Interfases;
using System;

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
			view.Show();
		}

		private void View_EventInputRandom(object sender, Common.Events.EventArgsRandom e)
		{
			model.UpdateMatrix += Model_UpdateMatrix;
			var input = new RandomInput(e.row, e.coll, e.max);
			model.InputMatrix(input.Leading());
		}

		private void View_EventInputFille(object sender, Common.Events.EventArgsFile e)
		{
			model.UpdateMatrix += Model_UpdateMatrix;
			var input = new FileInput(e.fileName);
			if (!input.fileExists) {
				view.ShowError("Файлу з введеною назвою не існує!");
				view.Show();
			} else if (!input.fileValid)
			{
				view.ShowError("Файл з введеною назвою не має формату csv!");
				view.Show();
			}
			model.InputMatrix(input.Leading());
		}

		private void View_EventInputManually(object sender, Common.Events.EventArgsManually e)
		{
			model.UpdateMatrix += Model_UpdateMatrix;
			var input = new ManualInput(e._coll, e._row);
			model.InputMatrix(input.Leading());
		}

		private void Model_UpdateMatrix(int[,] matrix)
		{
			view.EventSort += View_EventSort;
			view.InputMatrix(matrix);
		}

		private void View_EventSort(Common.Enums.Sorts obj)
		{
			model.SortsMatrix += Model_SortsMatrix;
			model.SortMatrix(obj);
		}

		private void Model_SortsMatrix(object sender, Common.Events.EventUpdateMatrix e)
		{
			view.SortMatrix(e.matrix, e.time, e.type);
		}
	}
}
