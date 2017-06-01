using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Models
{
    class MesseList
    {
    }
    public class Info
    {
        public string advertiser { get; set; }
        public string advertiser_url { get; set; }
        public string anzahl { get; set; }
        public string xml_datum { get; set; }
    }

    public class Venue
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Venues
    {
        public Venue venue { get; set; }
    }

    public class MesseState
    {
    }
    public class Partylist
    {
        public string id { get; set; }
        public string nameParty { get; set; }
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
        public string nameType { get; set; }
        public string nameCountry { get; set; }
        public string isoCountry { get; set; }
        public string nameTown { get; set; }
        public string geoLat { get; set; }
        public string geoLon { get; set; }
        public string nameOrganizer { get; set; }
        public string urlOrganizer { get; set; }
        public string urlImageSmall { get; set; }
        public string urlImageMedium { get; set; }
        public string dateCreated { get; set; }
        public string dateModified { get; set; }
        public string nameStatus { get; set; }
        public string urlPartyHtml { get; set; }
        public string urlPartyJson { get; set; }
    }
    public class Messe
    {
        public string id { get; set; }
        public string title { get; set; }
        public string title_short { get; set; }
        public string messelink { get; set; }
        public string date_start { get; set; }
        public string date_end { get; set; }
        public string date_startiso8601 { get; set; }
        public string date_endiso8601 { get; set; }
        public string date_startut { get; set; }
        public string date_endut { get; set; }
        public Venues venues { get; set; }
        public string messe_city { get; set; }
        public MesseState messe_state { get; set; }
        public string messe_country { get; set; }
        public string messe_typ { get; set; }
    }
    public class Partys
    {
        public List<Partylist> Partylist { get; set; }


    }
    public class Messen
    {
        public List<Messe> messe { get; set; }
        public List<Partylist> partylist { get; set; }

    }

    public class MesseListe
    {
        public Info info { get; set; }
        public Messen messen { get; set; }
        public List<Partylist> partylist { get; set; }
    }
}
