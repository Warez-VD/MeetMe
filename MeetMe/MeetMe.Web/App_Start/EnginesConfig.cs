using System.Web.Mvc;

namespace MeetMe.Web.App_Start
{
    public static class EnginesConfig
    {
        public static void RemoveWebFormsEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}