// Updated by XamlIntelliSenseFileGenerator 3/12/2024 11:17:52 PM
#pragma checksum "..\..\..\TeacherDashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52392468C6009674900597F344B5CD7E3151EACC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PRN221_Project;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PRN221_Project
{


    /// <summary>
    /// TeacherDashboard
    /// </summary>
    public partial class TeacherDashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 20 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;

#line default
#line hidden


#line 21 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;

#line default
#line hidden


#line 26 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTeacherId;

#line default
#line hidden


#line 28 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbClassId;

#line default
#line hidden


#line 30 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbClassName;

#line default
#line hidden


#line 33 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;

#line default
#line hidden


#line 34 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReload;

#line default
#line hidden


#line 35 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;

#line default
#line hidden


#line 39 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStudentsDetails;

#line default
#line hidden


#line 40 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageWorkInClass;

#line default
#line hidden


#line 45 "..\..\..\TeacherDashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvClass;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PRN221_Project;component/teacherdashboard.xaml", System.UriKind.Relative);

#line 1 "..\..\..\TeacherDashboard.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 8 "..\..\..\TeacherDashboard.xaml"
                    ((PRN221_Project.TeacherDashboard)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.tbSearch = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.btnSearch = ((System.Windows.Controls.Button)(target));

#line 21 "..\..\..\TeacherDashboard.xaml"
                    this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.tbTeacherId = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 5:
                    this.tbClassId = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.tbClassName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 7:
                    this.btnClear = ((System.Windows.Controls.Button)(target));

#line 33 "..\..\..\TeacherDashboard.xaml"
                    this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.btnReload = ((System.Windows.Controls.Button)(target));

#line 34 "..\..\..\TeacherDashboard.xaml"
                    this.btnReload.Click += new System.Windows.RoutedEventHandler(this.btnReload_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.btnLogout = ((System.Windows.Controls.Button)(target));

#line 35 "..\..\..\TeacherDashboard.xaml"
                    this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.btnStudentsDetails = ((System.Windows.Controls.Button)(target));

#line 39 "..\..\..\TeacherDashboard.xaml"
                    this.btnStudentsDetails.Click += new System.Windows.RoutedEventHandler(this.btnStudentsDetails_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.btnManageWorkInClass = ((System.Windows.Controls.Button)(target));

#line 40 "..\..\..\TeacherDashboard.xaml"
                    this.btnManageWorkInClass.Click += new System.Windows.RoutedEventHandler(this.btnManageWorkInClass_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.lvClass = ((System.Windows.Controls.ListView)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Button btnTakeAttendance;
    }
}

