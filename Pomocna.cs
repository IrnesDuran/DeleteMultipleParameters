using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proba1
{
    class Pomocna
    {
        FamilyParameter familyParameter = null;
        public Pomocna(FamilyParameter familyParameter)
        {
            this.familyParameter = familyParameter;
        }

        public FamilyParameter FamilyParameter
        {
            get { return familyParameter; }
        }

        public override string ToString()
        {
            return $"{familyParameter.Definition.Name}";
            // {familyParameter.Id}";
        }
    }
}
