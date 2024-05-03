Imports System.Resources

Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("PDA EPI Survey")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("ICF")> 
<Assembly: AssemblyProduct("PDA EPI")> 
<Assembly: AssemblyCopyright("Copyright © CDC 2010")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: CLSCompliant(True)> 

<Assembly: ComVisible(False)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("7f0b6cf3-6f1e-4fe9-a6aa-f2782dad271b")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.0.0.0")> 

'Below attribute is to suppress FxCop warning "CA2232 : Microsoft.Usage : Add STAThreadAttribute to assembly"
' as Device app does not support STA thread.
<Assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")> 

<Assembly: NeutralResourcesLanguageAttribute("en")> 