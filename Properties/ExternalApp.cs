using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1.Properties
{
    public class DeletePar : IExternalApplication
    {


        public Result OnStartup(UIControlledApplication application)
        {


            string dll = @"C:\ProgramData\Autodesk\Revit\Addins\2017\DeleteParameters.dll";

            RibbonPanel panel = application.CreateRibbonPanel("Delete Multiple Parameters");



            PushButton btnOne = (PushButton)panel.AddItem(new PushButtonData("One", "Thank you", dll, "DeleteParameters.ParametriKomanda"));


            btnOne.ToolTip = "Hide or show PointCloud links inside active view";
            btnOne.LongDescription = "This command toggles visibility of PointCloud links in active view. By hitting this command button, visibility is turned off if visibile, and vice versa.";
            btnOne.LargeImage = new BitmapImage(new Uri("https://i.imgur.com/IHa98v9.png"));
            btnOne.Image = new BitmapImage(new Uri("http://i65.tinypic.com/5vp4k5.jpg"));
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {

            return Result.Succeeded;
        }

    }
}
