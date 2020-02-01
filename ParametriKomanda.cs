using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Proba1.Forme;

namespace DeleteParameters
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class ParametriKomanda : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            if (!doc.IsFamilyDocument)
            {
                TaskDialog.Show("Not a family editor", "Please go to family editor mode");
                return Result.Cancelled;
            }
            FamilyManager mgr = doc.FamilyManager;
            FamilyParameterSet fps = mgr.Parameters;



            TaskDialog.Show("Parameters", "There are " + fps.Size.ToString() + " parameters inside this family. Please choose which should be removed.");

            var data = fps.Cast<FamilyParameter>().ToList();

            using (prvaLista prvaForma = new prvaLista(data))
            {
                if (prvaForma.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {



                    try
                    {
                        using (Transaction transaction = new Transaction(doc))
                        {
                            transaction.Start("Delete Multiple Parameters");
                            foreach (var item in prvaForma.SelektovanaLista)
                            {
                                mgr.RemoveParameter(item);
                            }
                            TaskDialog.Show("Parameters deleted", prvaForma.SelektovanaLista.Count().ToString() + " parameters have been deleted");
                            transaction.Commit();
                        }
                    }

                    catch (Exception)
                    {
                        using (Transaction transaction = new Transaction(doc))
                        {
                            transaction.Start("Delete Multiple Parameters Failed");
                            TaskDialog.Show("Cannot be deleted", "Built-in parameter cannot be deleted");
                            transaction.RollBack();
                        }
                    }


                }

            }

            return Result.Succeeded;
        }
    }
}
