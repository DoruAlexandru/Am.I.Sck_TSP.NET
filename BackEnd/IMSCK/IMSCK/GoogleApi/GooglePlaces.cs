using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Response;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;

namespace GoogleApi
{
    /// <summary>
    /// Methods to access Google Places Api: 
    /// https://developers.google.com/places/web-service/intro
    /// </summary>
    public class GooglePlaces
    {
        /// <summary>
        /// The Place Photo service, part of the Google Places API Web Service, is a read-only API that allows you to add high quality photographic content to your application. 
        /// The Place Photo service gives you access to the millions of photos stored in the Places and Google+ Local database. When you get place information using a Place Details request, 
        /// photo references will be returned for relevant photographic content. The Nearby Search and Text Search requests also return a single photo reference per place, when relevant. 
        /// Using the Photo service you can then access the referenced photos and resize the image to the optimal size for your application.
        /// https://developers.google.com/places/web-service/photos
        /// </summary>
        public static HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse> Photos => HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>.instance;

        /// <summary>
        /// The Google Places API Find Search Service is a web service that returns information about a set of places based on an input.
        /// A Find Place request takes a text input, and returns a place.
        /// The text input can be any kind of Places data, for example, a name, address, or phone number.
        /// https://developers.google.com/places/web-service/search#FindPlaceRequests
        /// </summary>
        public static HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse> FindSearch => HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>.instance;

        /// <summary>
        /// The Google Places API Text Search Service is a web service that returns information about a set of places based on a string — for example "pizza in New York" or "shoe stores near Ottawa". 
        /// The service responds with a list of places matching the text string and any location bias that has been set. 
        /// The search response will include a list of places, you can send a Place Details request for more information about any of the places in the response.
        /// https://developers.google.com/places/web-service/search
        /// </summary>
        public static HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse> TextSearch => HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>.instance;

        /// <summary>
        /// A Nearby Search lets you search for places within a specified area. 
        /// You can refine your search request by supplying keywords or specifying the type of place you are searching for
        /// https://developers.google.com/places/web-service/search
        /// </summary>
        public static HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse> NearBySearch => HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>.instance;

        /// <summary>
        /// Once you have a place_id from a Place Search, you can request more details about a particular establishment or point of interest by initiating a Place Details request. 
        /// A Place Details request returns more comprehensive information about the indicated place such as its complete address, phone number, user rating and reviews.
        /// https://developers.google.com/places/web-service/details
        /// </summary>
        public static HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse> Details => HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>.instance;

        /// <summary>
        /// The Query Autocomplete service can be used to provide a query prediction for text-based geographic searches, by returning suggested queries as you type.
        /// https://developers.google.com/places/web-service/query
        /// </summary>
        public static HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse> AutoComplete => HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>.instance;

        /// <summary>
        /// The Place Autocomplete service is a web service that returns place predictions in response to an HTTP request. 
        /// The request specifies a textual search string and optional geographic bounds. The service can be used to provide autocomplete functionality for text-based geographic searches, 
        /// by returning places such as businesses, addresses and points of interest as a user types.
        /// https://developers.google.com/places/web-service/autocomplete
        /// </summary>
        public static HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse> QueryAutoComplete => HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>.instance;
    }
}