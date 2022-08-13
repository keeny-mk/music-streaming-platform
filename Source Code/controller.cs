using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicService
{
    class controller
    {
        private DBManager musicMan; // A Reference of type DBManager 
                                 // (Initially NULL; NO DBManager Object is created yet)

        public controller()
        {
            musicMan = new DBManager(); // Create the DBManager Object
        }

        
        public int CheckPassword_Basic(string name, string password)
        {
            string query = "SELECT Priv from users" +
                " where Name= '" + name + "' AND Password = '" + password + "';";
            object p = musicMan.ExecuteScalar(query);
            if (p == null)
                return -1;
            else
                return Convert.ToInt32(p);
        }

        public void TerminateConnection()
        {
            musicMan.CloseConnection();
        }
        public int Insert_User(string id, string pass, string name, int phone, int age, string gender)
        {
            string query = "insert into users values ('"+id+"','"+pass+"','"+name+"',"+phone+","+age+",'"+gender+"',0)";
            return musicMan.ExecuteNonQuery(query);
        }
        public bool checkuserID(string id)
        {
            string query = "select cast (count(1) as bit) from users where id ='" + id + "'";
            return(bool) musicMan.ExecuteScalar(query);        
        }
        public DataTable getuserID(string name, string pass)
        {
            string query = "select ID from users where name='" + name + "'and password='" + pass + "'";
            return musicMan.ExecuteReader(query);
        }
        public DataTable select_title_Playlists(string userid)
        {
            string query = "select Title from Playlists where UserID='" + userid + "'";
            return musicMan.ExecuteReader(query);
        }
        public DataTable select_trackstitle_PlayLists(string id, string playlisttitle)
        {
            string query = "select tracktitle, a.title, a.ID from Playlist_Track, Albums a where UserID='"+id+"' and " +
                "PlaylistTitle='"+playlisttitle+"' and a.ID=AlbumID;";
            return musicMan.ExecuteReader(query);
        }
        public bool checkPlaylistTitle(string id,string title)
        {
            string query = "select cast (count(1) as bit) from users where UserID ='" + id + "' and Title='"+title+"'";
            return (bool)musicMan.ExecuteScalar(query);
        }
        public int CreatePlaylist(string userid, string title)
        {
            string query = "insert into Playlists(UserID,Title) values('" + userid + "','" + title + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public DataTable SelectTracks()
        {
            string query = "Select* from Tracks";
            return musicMan.ExecuteReader(query);
        }
        public DataTable SelectAlbums()
        {
            string query = "Select* from Albums";
            return musicMan.ExecuteReader(query);
        }
        public DataTable SelectArtists()
        {
            string query = "Select* from Artists";
            return musicMan.ExecuteReader(query);
        }
        public DataTable Select_Tracks_Artists_Albums()
        {
            string query = "select t.Title as track, ab.Title as album,a.Name as artist," +
                " ab.ID as albumid, a.ID as artistid " +
                "from (tracks t join albums ab on t.Album_ID=ab.ID) join artists a on a.ID=ab.ArtistID  ";
            return musicMan.ExecuteReader(query);
        }
        public DataTable SelectTracksby_Artists_Albums(List<string> artist,List<string> album)
        {
            string query = "select t.Title as track, ab.ID as albumid, a.ID as artistid" +
                " from tracks t, albums ab, artists a where t.Album_ID=ab.ID  and ab.ArtistID=a.ID and" +
                " (ab.ID in ('" + String.Join("','", album.Select(albumid => albumid.ToString()).ToArray()) + "')" +
                " or a.ID in('" + String.Join("','", artist.Select(artistid => artistid.ToString()).ToArray()) + "'))";
            return musicMan.ExecuteReader(query);
        }
        public DataTable SelectPlayTrack(string tracktitle, string albumid)
        {
            string query = "select t.title as track, ab.Title as album, a.Name as artist, audio " +
                "from tracks t, albums ab, Artists a " +
                " where t.Album_ID = ab.ID and ab.ArtistID = a.ID and t.Title = '"+tracktitle+"' and ab.ID = '"+albumid+"'";
            return musicMan.ExecuteReader(query);
        }
        public bool checkPlalylist_track(string userid, string playlisttitle, string albumid, string tracktitle)
        {
            string query = "select cast(count(1) as bit) from Playlist_Track " +
                "where AlbumID='"+albumid+"' and TrackTitle='"+tracktitle+"' and UserID='"+userid+"'and PlaylistTitle='"+playlisttitle+"'";
            return (bool)musicMan.ExecuteScalar(query);
        }
        public int AddtoPlaylist(string userid,string playlisttitle, string albumid, string tracktitle)
        {
            string query = "insert into Playlist_Track " +
                "values('" + userid + "','" + playlisttitle + "','" + albumid + "','" + tracktitle + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public int DeleteFromPlaylist(string userid, string playlisttitle, string albumid, string tracktitle)
        {
            string query = "delete from Playlist_Track " +
                "where UserID='" + userid + "'and PlaylistTitle='" + playlisttitle + "' and " +
                "AlbumID='" + albumid + "' and TrackTitle='" + tracktitle + "'";
            return musicMan.ExecuteNonQuery(query);
        }
        public int DeletePlaylist(string id, string playlisttitle)
        {
            string query = " delete from Playlist_Track where UserID='" + id + "'and PlaylistTitle='" + playlisttitle + "' " +
                "delete from Playlists where UserID = '" + id + "'and Title = '" + playlisttitle + "'";
            return musicMan.ExecuteNonQuery(query);
        }
        public int Insert_Artist(string artisitname,string id)
        {
            string query = "insert into Artists Values('" + artisitname + "','" + id + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public int Inser_ArtistGenre(string id, string genre)
        {
            string query = "insert into artist_genre values('" + id + "','" + genre + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public int Insert_Musician(string name, string gender, int age, string artisitID)
        {
            string query = "insert into Musician values('" + name + "','" + gender + "'," + age + ",'" + artisitID + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public DataTable Select_Genres()
        {
            string query = "select* from Genres";
            return musicMan.ExecuteReader(query);
        }
        public int Insert_User_Artist(string id, string pass, string name, int phone)
        {
            string query = "insert into users values ('" + id + "','" + pass + "','" + name + "'," + phone + ",null,null,1)";
            return musicMan.ExecuteNonQuery(query);
        }
        public int insertArtist_Genre(string id, string genre)
        {
            string query = "insert into Artist_Genre Values('" + id + "','" + genre + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public int Insert_Album(string Title, string ID, string UID)
        {
            string query = "insert into Albums values ('" + Title + "','" + ID + "',null,'" + UID + "')";
            return musicMan.ExecuteNonQuery(query);
        }

        public int Insert_Track(string Title, string length, string AlbumID, string Path)
        {
            string query = "insert into tracks values ('" + Title + "','" + length + "',null,'" + AlbumID + "',null,'" + Path + "')";
            return musicMan.ExecuteNonQuery(query);
        }
        public DataTable ListAlbumsArtist(string ID)
        {
            string query = "select Title from ALbums where ArtistID='" + ID + "'";
            return musicMan.ExecuteReader(query);
        }
        public DataTable ListTracksArtist(string ID)
        {
            string query = "select Title from Tracks where Album_ID in(select ID from ALbums where ArtistID ='" + ID + "')";
            return musicMan.ExecuteReader(query);

        }
        public int insert_concert(double price, DateTime date, string time, string aid, string pid)
        {
            string query = "insert into concerts values('" + price + "','" + date.ToString("yyyy-MM-dd") +" "+time+"','" + pid + "','" + aid + "')";
                return musicMan.ExecuteNonQuery(query);
        }
        public DataTable selectArtistAlbums(string id)
        {
            string query = "select title, id from albums where artistID='" + id + "'";
            return musicMan.ExecuteReader(query);
        }
        public int updatepassword(string newpass,string id, string oldpass)
        {
            string query = "update users set Password='" + newpass + "' where ID='" + id + "' and Password='" + oldpass + "'";
            return musicMan.ExecuteNonQuery(query);
        }
        public DataTable genrestats()
        {
            string query = "select genrename as Genre, count(*)as NumberOfArtists from Artist_Genre join Artists on ArtistID=ID group by GenreName";
            return musicMan.ExecuteReader(query);
        }
        public DataTable artiststats()
        {
            string query = "select a.name as Artist, count(t.title) as NumberOfTracks from (tracks t join Albums ab on Album_ID=ab.ID)join Artists a on ArtistID=a.ID group by a.Name";
            return musicMan.ExecuteReader(query);
        }
        public DataTable artiststats2()
        {
            string query = "select a.Name as Artist, count(ab.title) as NumberOfAlbums from Albums ab join Artists a on ArtistID=a.ID group by a.name ";
            return musicMan.ExecuteReader(query);
        }

    }
}
