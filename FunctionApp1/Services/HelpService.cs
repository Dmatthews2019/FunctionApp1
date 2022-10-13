using System.IO;
using FunctionApp1.Repository;

namespace SimpleApiCalculator.Services
{
    internal class HelpService
    {
        private string helpResponse;
        public string HelpResponse { get { return helpResponse; } }
        public HelpService()
        {
            //Real World would be pulling from an Azure storage.
            SetHelpResponse();
        }

        private void SetHelpResponse()
        {
            helpResponse = File.ReadAllText(Statics.HelpFilePath);
        }
    }
}
