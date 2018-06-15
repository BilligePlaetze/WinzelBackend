namespace WinzelBackend.Utilites
{
    using System.Collections.Generic;
    using WinzelBackend.Models;

    public class CrackHoe
    {
        public static void CommentBitch(WinzelContext context)
        {
            var comment1 = BuildComment("Glückwunsch! Haben Sie etwas anderes gemacht als in den vorhrigen Jahren?");
            context.WinzelComments.Add(comment1);
            context.SaveChanges();
        }

    public static void HaveSex(WinzelContext context)
        {
            var hashtag1 = new WinzelHashTag();
            hashtag1.HashTag = "Probleme";
            var hashtag2 = new WinzelHashTag();
            hashtag2.HashTag = "Insekten";
            var hashtag3 = new WinzelHashTag();
            hashtag3.HashTag = "Weinkrankheiten";
            var hashtag4 = new WinzelHashTag();
            hashtag4.HashTag = "Wetter";
            var hashtag5 = new WinzelHashTag();
            hashtag5.HashTag = "Schädlinge";

            var hashTags1 = new List<WinzelHashTag>() {hashtag1, hashtag2};
            var hashTags2 = new List<WinzelHashTag>() { hashtag3, hashtag4 };
            var hashTags3 = new List<WinzelHashTag>() { hashtag5, hashtag1 };
            var hashTags4 = new List<WinzelHashTag>() { hashtag2, hashtag3 };
            var hashTags5 = new List<WinzelHashTag>() { hashtag4, hashtag5 };

            var comment1 = BuildComment("Glückwunsch! Haben Sie etwas anderes gemacht als in den vorhrigen Jahren?");
            var winzel1 =
                BuildWinzel("Bester Ertrag seit langem!", "Ich habe dieses Jahr einen besseren Ertrag als in den letzten Jahren erzielen können!", "Helmut", "heute", "nah", "https://www.duden.de/_media_/full/W/Weinernte-201020522481.jpg",
                hashTags1,
                new List<WinzelComment>() { comment1 });

            var comment2 = BuildComment("Nein zum Glück nicht! Wie hoch sind denn die Schäden bei Ihnen?");
            var comment21 = BuildComment("Viel Erfolg ihnen!");
            var winzel2 = BuildWinzel(
                "Schäden druch extreme Wetterlagen!",
                "Ich habe große schäden auf meinem Weingut druch den Sturm Helga erlitten. Ging das noch jemandem so?",
                "Peter",
                "heute",
                "weit",
                "https://www.bmel.de/SharedDocs/Bilder/Fachbereiche/Landwirtschaft/NachhaltigkeitOekolandbau/Extremwetterlage.jpg;jsessionid=46B9DDB1780C701FA2C9F4F93860A975.2_cid288?__blob=poster&v=2",
                hashTags2,
                new List<WinzelComment>() { comment2, comment21 });

            var comment3 = BuildComment("leider nein");
            var comment31 = BuildComment("Ich!");
            var comment32 = BuildComment("Hier auch");
            var winzel3 = BuildWinzel(
                "Digitalisierung im Weinbau",
                "Geht noch wer auf den Kongress in Stuttgart zum Thema Digitalisierung im Weinbau? Wir könnten eine Fahrgemeinschaft organisieren!",
                "Maria",
                "heute",
                "weit",
                "https://www.kukksi.de/wp-content/uploads/2017/11/St-136-Gewitter-BILD-iStock.jpg",
            hashTags3,
                new List<WinzelComment>() { comment3, comment31, comment32 });


            context.Winzels.Add(winzel1);
            context.Winzels.Add(winzel2);
            context.Winzels.Add(winzel3);
            context.SaveChanges();
        }

        private static Winzel BuildWinzel(string titel, string text, string autor, string date, string location, string image, List<WinzelHashTag> hashtags ,List<WinzelComment> usedComments)
        {

            var gab1 = new WinzelGrapes();
            gab1.Gab = "traube1";

            var winzel = new Winzel();
            winzel.WinzelAuthor = autor;
            winzel.WinzelDate = date;
            winzel.WinzelLocation = location;
            winzel.WinzelHashTags = hashtags;
            winzel.WinzelImage = image;
            winzel.WinzelGraps = new List<WinzelGrapes>() { gab1 };
            winzel.WinzelTitle = titel;
            winzel.WinzelComments = usedComments;
            winzel.WinzelText = text;

            return winzel;
        }

        private static WinzelComment BuildComment(string text, string date = "heute")
        {
            var comment = new WinzelComment();
            comment.Text = text;
            comment.Date = date;
            return comment;
        }

        public static void SpreadFakeNewws(WinzelContext context)
        {
            var newsFeed = new WinzelNewsFeed();
            newsFeed.Image = "https://sebsblogs.files.wordpress.com/2011/03/ugly.jpg";
            newsFeed.Text = "hohoehoe";
            newsFeed.Title = "Henne Zukunft";
            context.WinzelNewsFeed.Add(newsFeed);

            var newsFeed1 = new WinzelNewsFeed();
            newsFeed.Image = "https://de.wikipedia.org/wiki/Datei:Botrytis_riesling.jpg";
            newsFeed.Text = "Die Edelfäule (auch Edelreife) nennt man das Auftreten des Schimmelpilzes Botrytis cinerea, auch Grauschimmel genannt, auf den reifen Beeren der Weintraube.";
            newsFeed.Title = "Riesling Edelfäule";
            context.WinzelNewsFeed.Add(newsFeed1);
            context.SaveChanges();

            var newsFeed2 = new WinzelNewsFeed();
            newsFeed.Image = "https://www.kukksi.de/wp-content/uploads/2017/11/St-136-Gewitter-BILD-iStock.jpg";
            newsFeed.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";
            newsFeed.Title = "Starkes Gewitter am 08.06.2018";
            context.WinzelNewsFeed.Add(newsFeed1);
            context.SaveChanges();

        }
    }
}