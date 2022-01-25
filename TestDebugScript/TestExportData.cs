using EAS.LeegooBuilder.Server.BusinessLayer.ScriptEngine;

namespace EAS.LeegooBuilder.Server.DebugScript.TestExport
{
    /// <summary>
    /// Sample class with some demonstration methods
    /// </summary>
    public class TestExportData : BusinessLayer.ScriptEngine.DebugScript.DebugScript
    {
        private readonly string _yourName;
        
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="scriptContext"></param>
        public TestExportData(ScriptContext scriptContext) : base(scriptContext) { }
        
        
        /// <summary>
        /// Constructor overload with additional parameter
        /// </summary>
        /// <param name="scriptContext"></param>
        /// <param name="yourName"></param>
        public TestExportData(ScriptContext scriptContext, string yourName) : base(scriptContext)
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
        /// Gives access to the second constructor parameter variable
        /// </summary>
        /// <returns></returns>
        public string GetYourName() => _yourName;
    }
}