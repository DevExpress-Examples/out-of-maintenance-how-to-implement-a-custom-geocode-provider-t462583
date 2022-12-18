<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128571551/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T462583)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/CustomGeocodeProvider/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/CustomGeocodeProvider/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/CustomGeocodeProvider/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/CustomGeocodeProvider/MainWindow.xaml.vb))
<!-- default file list end -->
# How to: Implement a Custom Geocode Provider


This example demonstrates how to create a custom geocode provider.


<h3>Description</h3>

To do this, design a class inheriting&nbsp;the&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapInformationDataProviderBasetopic">InformationDataProviderBase</a>&nbsp;class and the&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapIMouseClickRequestSendertopic">IMouseClickRequestSender</a>&nbsp;interface,&nbsp;and implement the CreateData() and <br>RequestByPoint() &nbsp;methods in the class. Then, design a class inheriting the&nbsp;<a href="https://documentation.devexpress.com/#WPF/clsDevExpressXpfMapIInformationDatatopic">IInformationData</a>&nbsp;interface and override its&nbsp;<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfMapIInformationData_OnDataResponsetopic">OnDataResponse</a>&nbsp;event. Implement the <strong>CalculateAddress</strong>&nbsp;method to provide custom geocode&nbsp;logic.

<br/>


