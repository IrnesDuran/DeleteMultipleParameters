using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proba1.Forme
{
    public partial class prvaLista : System.Windows.Forms.Form
    {

        List<FamilyParameter> list = null;

        public List<FamilyParameter> SelektovanaLista
        {
            get { return list; }
        }

        public prvaLista(List<FamilyParameter> list)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            PopuniListu(list.Select(x => new Pomocna(x)).ToList());
        }

        private void PopuniListu(List<Pomocna> list)
        {
            foreach (var item in list)
            {
                listBoxData.Items.Add(item);
            }

        }

        private void listBoxData_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBoxData.SelectedIndex != -1)
            {


                list = listBoxData.SelectedItems
                    .Cast<Pomocna>()
                    .Select(x => x.FamilyParameter).ToList();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void listBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
