using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * Model View Presentation
 * */
namespace MVP
{
    public partial class FrmMvp : Form, IView
    {
        private Presenter _presenter = null;
        private readonly Model _model;

        public FrmMvp(Model model)
        {
            InitializeComponent();
            _model = model;
            _presenter = new Presenter(this, _model);
            SubscribeToModelEvents();
        }

        public string TextValue
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        private void cmdSet_Click(object sender, EventArgs e)
        {
            _presenter.SetTextValue();
        }

        private void CmdReverse_Click(object sender, EventArgs e)
        {
            _presenter.ReverseTextValue();
        }

        private void SubscribeToModelEvents()
        {
            _model.TextSet += _model_TextSet;
        }

        void _model_TextSet(object sender, CustomArgs e)
        {
            this.textBox1.Text = e._after;
            //this.label1.Text = "Text changed from " + e.m_before + " to " + e.m_after;
        }
    }

   

}



