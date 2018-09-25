using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP
{

    /*
     *  [ USER ]  <========> VIEW  <-----> Presenter  <-----> Model
     *  
     * */

    /* VIEW
     * The View represents the UI components like CSS, jQuery, html etc. 
     * It is only responsible for displaying the data that is received from the presenter as the result. 
     * This also transforms the model(s) into UI.
     * */
    public interface IView
    {
        string TextValue { get; set; }
    }

    /* PRESENTER
     * The Presenter is responsible for handling all UI events on behalf of the view. 
     * This receive input from users via the View, then process the user's data with 
     * the help of Model and passing the results back to the View. 
     * Unlike view and controller, view and presenter are completely decoupled from 
     * each other’s and communicate to each other’s by an interface.
     *  Also, presenter does not manage the incoming request traffic as controller.
     * */
    public class Presenter
    {
        private readonly IView _view;
        private readonly IModel _model;

        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
        }
        public void ReverseTextValue()
        {
            string reversed = ReverseString(_view.TextValue);
            _model.Reverse(reversed);
        }

        public void SetTextValue()
        {
            _model.Set(_view.TextValue);
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }

    /* MODEL
     * The Model represents a set of classes that describes the BUSINESS logic and data. 
     * It also defines business rules for data means how the data can be changed and manipulated.
     * */
    public interface IModel
    {
        void Set(string value);
        void Reverse(string value);
    }

    public class CustomArgs : EventArgs
    {
        public string _before { get; set; }
        public string _after { get; set; }

        public CustomArgs(string before, string after)
        {
            _before = before;
            _after = after;
        }
    }

    public class Model : IModel
    {
        private string _textValue;
        public event EventHandler<CustomArgs> TextSet;
        public event EventHandler<CustomArgs> TextReverse;

        public Model()
        {
            _textValue = "";
        }

        public void Reverse(string value)
        {
            string before = _textValue;
            _textValue = value;
            RaiseTextSetEvent(before, _textValue);
        }

        public void Set(string value)
        {
            string before = _textValue;
            _textValue = value;
            RaiseTextSetEvent(before, _textValue);
        }

        public void RaiseTextSetEvent(string before, string after)
        {
            TextSet(this, new CustomArgs(before, after));
        }
    }
}
