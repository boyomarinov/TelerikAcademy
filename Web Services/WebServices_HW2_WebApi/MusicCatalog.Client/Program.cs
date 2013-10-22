using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using MusicCatalog.Data;
using MusicCatalog.Data.Migrations;
using MusicCatalog.Model;

namespace MusicCatalog.Client
{
    public static class Program
    {
        public static void Main()
        {
            #region json
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:19872/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //foreach (var c in MusicCatalogDAL.GetAlbums(client))
            //{
            //    Console.WriteLine(c.AlbumId + " " + c.Title);
            //}
            //Console.WriteLine();

            //Artist artistToAdd = new Artist()
            //    {
            //        Name = "Random name 3",
            //        Age = 35,
            //        Country = "Bulgaria"
            //    };
            //MusicCatalogDAL.AddArtist(client, artistToAdd);
            //MusicCatalogDAL.GetArtists(client);

            //Album updatedAlbum = new Album()
            //    {
            //        AlbumId = 8,
            //        Title = "xml Title",
            //        Year = 1234
            //    };
            //MusicCatalogDAL.UpdateAlbum(client, 8, updatedAlbum);
            //MusicCatalogDAL.GetAlbums(client);
            //MusicCatalogDAL.DeleteAlbum(client, 7);

            //Album newAlbum = new Album()
            //{
            //    Title = "Album with songs",
            //    Year = 2010
            //};
            //Song first = new Song()
            //{
            //    Title = "First Song",
            //    Genre = "Rock"
            //};
            //Song second = new Song()
            //{
            //    Title = "Second Song",
            //    Genre = "House"
            //};

            //newAlbum.Songs.Add(first);
            //newAlbum.Songs.Add(second);
            //MusicCatalogDAL.AddAlbum(client, newAlbum);

            #endregion

            var client2 = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:19872/")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            Album newXmlAlbum = new Album()
            {
                Title = "Album with xmlsongs",
                Year = 2010
            };
            Song xmlFirst = new Song()
            {
                Title = "First xmlSong",
                Genre = "Rock"
            };
            Song xmlSecond = new Song()
            {
                Title = "Second xmlSong",
                Genre = "House"
            };

            newXmlAlbum.Songs.Add(xmlFirst);
            newXmlAlbum.Songs.Add(xmlSecond);
            MusicCatalogDAL.AddAlbum(client2, newXmlAlbum);

        }
    }
}
