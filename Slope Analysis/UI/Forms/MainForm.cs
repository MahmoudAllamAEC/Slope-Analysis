using Slope_Analysis.UI.ViewModels;
using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Slope_Analysis.UI.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private MainViewModel _viewModel;

        public MainForm()
        {
            InitializeComponent();
        }
        public void SetViewModel(MainViewModel viewModel)
        {
            _viewModel = viewModel;
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            }
            BindToViewModel();
        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainViewModel.SelectedFloors))
            {
                UpdateSelectedFloorsCount();
            }
        }
        private void BindToViewModel()
        {
            txtStartRange.DataBindings.Clear();
            txtEndRange.DataBindings.Clear();
            
            txtStartRange.DataBindings.Add("Text", _viewModel, "StartRange", false, DataSourceUpdateMode.OnPropertyChanged);
            txtEndRange.DataBindings.Add("Text", _viewModel, "EndRange", false, DataSourceUpdateMode.OnPropertyChanged);
            UpdateSelectedFloorsCount();
        }
        private void UpdateSelectedFloorsCount()
        {
            if(_viewModel != null)
            {
                lblSelectedCount.Text = $"Selected: {_viewModel.SelectedFloors.Count}";

            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectFloors_Click(object sender, EventArgs e)
        {
            _viewModel?.SelectFloors();
            UpdateSelectedFloorsCount();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            _viewModel?.Apply();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _viewModel?.Reset();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Ensure reset is called when the form is closed
            _viewModel?.Reset();

            // Unsubscribe from events to prevent memory leaks
            if (_viewModel != null)
            {
                _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
            }

            base.OnFormClosing(e);
        }
    }
}
