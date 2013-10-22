using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicCatalog.Model;

namespace MusicCatalog.Data
{
    public class MusicCatalogDAL
    {
        #region Album
        public static IEnumerable<Album> GetAlbums(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/albums").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                return albums;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static Album GetAlbum(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/albums/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                return albums.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddAlbum(HttpClient client, Album album)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/albums", album).Result;
            }
            else
            {
                response = client.PostAsJsonAsync("api/albums", album).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album {0} added successfully", album.Title);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateAlbum(HttpClient client, int id, Album album)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/albums/" + id, album).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/albums/" + id, album).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album {0} updated successfully", album.Title);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteAlbum(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion

        #region Artist
        public static IEnumerable<Artist> GetArtists(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/artists").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                return artists;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static Artist GetArtist(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/artists/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                return artists.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddArtist(HttpClient client, Artist artist)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/artists", artist).Result;
            }
            else
            {
                response = client.PostAsXmlAsync("api/artists", artist).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist {0} added successfully", artist.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateArtist(HttpClient client, int id, Artist artist)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/albums/" + id, artist).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/albums/" + id, artist).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist {0} updated successfully", artist.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteArtist(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion

        #region Song
        public static IEnumerable<Song> GetSongs(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync("api/songs").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                return songs;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static Song GetSong(HttpClient client, int id)
        {
            HttpResponseMessage response = client.GetAsync("api/songs/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                return songs.First();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static void AddSong(HttpClient client, Song song)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PostAsJsonAsync("api/songs", song).Result;
            }
            else
            {
                response = client.PostAsXmlAsync("api/songs", song).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist {0} added successfully", song.Title);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateSong(HttpClient client, int id, Artist song)
        {
            HttpResponseMessage response;
            if (client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
                response = client.PutAsJsonAsync("api/songs/" + id, song).Result;
            }
            else
            {
                response = client.PutAsXmlAsync("api/songs/" + id, song).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song {0} updated successfully", song.Name);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void DeleteSong(HttpClient client, int id)
        {
            HttpResponseMessage response = client.DeleteAsync("api/songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song {0} deleted successfully", id);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
        #endregion
    }
}
