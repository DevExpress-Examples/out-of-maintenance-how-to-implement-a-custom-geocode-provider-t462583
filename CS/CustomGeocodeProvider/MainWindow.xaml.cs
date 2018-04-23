using DevExpress.Xpf.Map;
using System;
using System.Windows;

namespace CustomGeocodeProvider {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            informationLayer.DataProvider = new GeocodeDataProvider();
        }
    }
    public class GeocodeDataProvider : InformationDataProviderBase, IMouseClickRequestSender {
        public GeocodeDataProvider() {
            this.ProcessMouseEvents = true;
        }
        protected new GeocodeData Data { get { return (GeocodeData)base.Data; } }
        public void RequestByPoint(GeoPoint geoPoint, Point screenPoint) {
            Data.CalculateAddress(geoPoint);
        }
        protected override IInformationData CreateData() {
            return new GeocodeData();
        }
        protected override MapDependencyObject CreateObject() {
            return new GeocodeDataProvider();

        }
        public override bool IsBusy {
            get {
                throw new NotImplementedException();
            }
        }
        public override void Cancel() {
            throw new NotImplementedException();
        }
    }
    public class GeocodeData : IInformationData {

        LocationInformation address = new LocationInformation();
        public LocationInformation Address { get { return address; } set { address = value; } }

        public event EventHandler<RequestCompletedEventArgs> OnDataResponse;
        RequestCompletedEventArgs CreateEventArgs() {
            MapItem item = new MapPushpin() { Location = address.Location, Information = address.Address.FormattedAddress };
            return new RequestCompletedEventArgs(new MapItem[] { item }, null, false, null);
        }
        protected void RaiseChanged() {
            if (OnDataResponse != null)
                OnDataResponse(this, CreateEventArgs());
        }
        public void CalculateAddress(GeoPoint geoPoint) {
            //Implement your custom geocode logic here
            LocationInformation info = new LocationInformation();
            info.Address = new Address("Address from your service here " + Environment.NewLine + "Coordinates: " + geoPoint.ToString());
            info.Location = new GeoPoint(geoPoint.Latitude, geoPoint.Longitude);
            Address = info;
            //
            RaiseChanged();
        }
    }
    public class Address : AddressBase {
        public Address(string address) {
            this.FormattedAddress = address;
        }

        protected override MapDependencyObject CreateObject() {
            throw new NotImplementedException();
        }
    }
}
