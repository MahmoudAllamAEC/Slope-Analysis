using System.Collections.Generic;
using System.ComponentModel;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Slope_Analysis.Revit.Utils;
using Slope_Analysis.UI.Models;

namespace Slope_Analysis.UI.ViewModels
{
    public class MainViewModel :INotifyPropertyChanged
    {

        //Fields and private storage for the properties
        private UIDocument _uidoc;

        private Document _doc;

        public ExternalEvent _generation { get; set; }

        public ExternalEvent _reset { get; set; }

        // the list if floors the user has picked
        private List<Element> _selectedFloors = new List<Element>();

        public IReadOnlyList<Element> SelectedFloors => _selectedFloors;
        
        //the slope range data model

        private SlopeRange _slopeRange { get; set; }
        
        public SlopeRange SlopeRange
        {
            get => _slopeRange;
            set
            {
                _slopeRange = value;
                OnPropertyChanged(nameof(SlopeRange));
            }
        }

        //Bindable flat properties for the text boxs
        public double StartRange
        {
            get => SlopeRange.StartRange;
            set
            {
                SlopeRange.StartRange = value;
                OnPropertyChanged(nameof(StartRange));
            }
        }
        
        public double EndRange
        {
            get => SlopeRange.EndRange;
            set
            {
                SlopeRange.EndRange = value;
                OnPropertyChanged(nameof(EndRange));
            }
        }

        //Constructor
        public MainViewModel(UIDocument uidoc ,Document doc ,ExternalEvent generation, ExternalEvent reset)
        {
            _uidoc = uidoc;
            _doc = doc;
            _generation = generation;
            _reset = reset;
            SlopeRange = new SlopeRange();
        }
        //methods
        public void SelectFloors()
        {
            // call the utility this triggrts the revit pick mode on the ui thread,
            //this is safe to call from the form because the pickibjects is a ui operation 
            // not a document operation
            _selectedFloors = SelectionUtils.SelectFloors(_uidoc, _doc);

            // tell the form that selectedfloors changed so it updates the count label
            OnPropertyChanged(nameof(SelectedFloors));
        }
        public void Apply()
        {
            _generation.Raise();
        }
        public void Reset()
        {
            _reset.Raise();
        }
        //INotifyPropertyChanged boilerplate
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string Name) =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));





    }
}
