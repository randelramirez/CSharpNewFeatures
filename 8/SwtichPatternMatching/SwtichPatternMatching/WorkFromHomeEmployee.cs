using System;
using System.Collections.Generic;
using System.Text;

namespace SwtichPatternMatching
{
    public class WorkFromHomeEmployee : Employee, IWorkFromHome
    {
        public WorkFromHomeEmployee(string name, DateTime birthDate, string companyName, string portalUserName): base(name, birthDate, companyName)
        {
            this.PortalUserName = portalUserName;
        }

        public string PortalUserName { get; } 
    }
}
