using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using BeachAndBytes.ToggleLineNumbers;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using EnvDTE80;

namespace StudioPackages.ToggleLineNumbers
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidToggleLineNumbersPkgString)]
    public sealed class ToggleLineNumbers : Package
    {
        private DTE2 _application;
        private bool _lineNumbersVisible;
        private List<string> _editorTypes;

        protected override void Initialize()
        {
            _application = (DTE2)GetService(typeof(DTE));
            _lineNumbersVisible = (bool)_application.Properties[@"TextEditor", "Basic"].Item(@"ShowLineNumbers").Value;
            _editorTypes = new List<string> { "PlainText", "CSharp", "HTML", "C/C++", "XML", "CSS", "Basic", "CSS", "FSharp", "Javascript", "Xaml" };
            base.Initialize();

            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null == mcs) return;
            mcs.AddCommand(new MenuCommand(MenuItemCallback, new CommandID(GuidList.guidToggleLineNumbersCmdSet, (int)PkgCmdIDList.cmdidToggleLineNumbers)));
        }

        private void MenuItemCallback(object sender, EventArgs e)
        {
            foreach (string editor in _editorTypes)
            {
                _application.Properties[@"TextEditor", editor].Item(@"ShowLineNumbers").Value = !_lineNumbersVisible;
            }
            _lineNumbersVisible = !_lineNumbersVisible;
        }
    }
}
