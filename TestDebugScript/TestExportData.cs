using System.Linq;
using EAS.LeegooBuilder.Business.Contracts.Interfaces;
using EAS.LeegooBuilder.Server.BusinessLayer.DynamicEntities;
//using System.Linq;*/


namespace EAS.LeegooBuilder.Server.DebugScript.TestExport
{
    /// <summary>
    /// Sample class with some demonstration methods
    /// </summary>
    public class TestExportData : DebugScript
    {
        private readonly string _yourName;
        
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="scriptContext"></param>
        public TestExportData(IScriptContext scriptContext) : base(scriptContext) { }
        
        
        /// <summary>
        /// Constructor overload with additional parameter
        /// </summary>
        /// <param name="scriptContext"></param>
        /// <param name="yourName"></param>
        public TestExportData(IScriptContext scriptContext, string yourName) : base(scriptContext)
        {
            _yourName = yourName;
        }
        
        
        /// <summary>
        /// Test method
        /// </summary>
        public void HelloWorld()
        {
            ShowMessageBox("Hello World!");
        }


        /// <summary>
        /// Liest beispielhaft einen Wert aus einer SQL-Tabelle.
        /// </summary>
        /// <returns></returns>
        public string TestEntityFramework()
        {
            var result = string.Empty;
            using var entity = new DynamicEntity(IdentityService, true);
            {
                var syslog = entity.SYS_LOG.FirstOrDefault(item => (item.EVENT == "AppVersion"));

                if (syslog?.DATA_1 != null)
                {
                    result = syslog.DATA_1;
                }
            }

            return result;
        }
        
        
        /// <summary>
        /// Gives access to the second constructor parameter variable
        /// </summary>
        /// <returns></returns>
        public string GetYourName() => _yourName;
    }
}