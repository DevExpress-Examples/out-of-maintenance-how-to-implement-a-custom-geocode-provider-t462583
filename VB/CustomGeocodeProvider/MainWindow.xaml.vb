Imports DevExpress.Xpf.Map
Imports System
Imports System.Windows

Namespace CustomGeocodeProvider
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            informationLayer.DataProvider = New GeocodeDataProvider()
        End Sub
    End Class
    Public Class GeocodeDataProvider
        Inherits InformationDataProviderBase
        Implements IMouseClickRequestSender

        Public Sub New()
            Me.ProcessMouseEvents = True
        End Sub
        Protected Shadows ReadOnly Property Data() As GeocodeData
            Get
                Return CType(MyBase.Data, GeocodeData)
            End Get
        End Property
        Public Sub RequestByPoint(ByVal geoPoint As GeoPoint, ByVal screenPoint As Point) Implements IMouseClickRequestSender.RequestByPoint
            Data.CalculateAddress(geoPoint)
        End Sub
        Protected Overrides Function CreateData() As IInformationData
            Return New GeocodeData()
        End Function
        Protected Overrides Function CreateObject() As MapDependencyObject
            Return New GeocodeDataProvider()

        End Function
        Public Overrides ReadOnly Property IsBusy() As Boolean
            Get
                Throw New NotImplementedException()
            End Get
        End Property
        Public Overrides Sub Cancel()
            Throw New NotImplementedException()
        End Sub

    End Class
    Public Class GeocodeData
        Implements IInformationData


        Private address_Renamed As New LocationInformation()
        Public Property Address() As LocationInformation
            Get
                Return address_Renamed
            End Get
            Set(ByVal value As LocationInformation)
                address_Renamed = value
            End Set
        End Property

        Public Event OnDataResponse As EventHandler(Of RequestCompletedEventArgs) Implements IInformationData.OnDataResponse

        Private Function CreateEventArgs() As RequestCompletedEventArgs
            Dim item As MapItem = New MapPushpin() With {.Location = address_Renamed.Location, .Information = address_Renamed.Address.FormattedAddress}
            Return New RequestCompletedEventArgs(New MapItem() {item}, Nothing, False, Nothing)
        End Function
        Protected Sub RaiseChanged()
            RaiseEvent OnDataResponse(Me, CreateEventArgs())
        End Sub
        Public Sub CalculateAddress(ByVal geoPoint As GeoPoint)
            'Implement your custom geocode logic here
            Dim info As New LocationInformation()
            info.Address = New Address("Address from your service here " & Environment.NewLine & "Coordinates: " & geoPoint.ToString())
            info.Location = New GeoPoint(geoPoint.Latitude, geoPoint.Longitude)
            Address = info
            '
            RaiseChanged()
        End Sub
    End Class
    Public Class Address
        Inherits AddressBase

        Public Sub New(ByVal address As String)
            Me.FormattedAddress = address
        End Sub

        Protected Overrides Function CreateObject() As MapDependencyObject
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
