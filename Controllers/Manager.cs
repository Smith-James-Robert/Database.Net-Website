using AutoMapper;
using JS2247A5.Data;
using JS2247A5.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;
// ************************************************************************************
// WEB524 Project Template V2 == 2241-a4f37647-6656-4ec2-8866-c660a8d05c3a
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace JS2247A5.Controllers
{
    public class Manager
    {

        // Reference to the data context
        private ApplicationDbContext ds = new ApplicationDbContext();

        // AutoMapper instance
        public IMapper mapper;

        // Request user property...

        // Backing field for the property
        private RequestUser _user;

        // Getter only, no setter
        public RequestUser User
        {
            get
            {
                // On first use, it will be null, so set its value
                if (_user == null)
                {
                    _user = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);
                }
                return _user;
            }
        }

        // Default constructor...
        public Manager()
        {
            // If necessary, add constructor code here

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();

                cfg.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();
                cfg.CreateMap<Genre, GenreBaseViewModel>();

                cfg.CreateMap<Show, ShowBaseViewModel>();
                cfg.CreateMap<Show,ShowWithDetailViewModel>();
                cfg.CreateMap<ShowAddViewModel, Show>();

                cfg.CreateMap<Episode, EpisodeBaseViewModel>();
                cfg.CreateMap<Episode,EpisodeVideoViewModel>();
                cfg.CreateMap<EpisodeAddViewModel, Episode>();


                cfg.CreateMap<Actor,ActorBaseViewModel>();
                cfg.CreateMap<ActorAddViewModel, Actor>();
                cfg.CreateMap<Actor,ActorWithShowInfoViewModel>();

                cfg.CreateMap<ActorMediaItem, ActorMediaItemWithContentViewModel>();
                
            });

            mapper = config.CreateMapper();
            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().




        // *** Add your methods ABOVE this line **

        #region Role Claims

        public List<string> RoleClaimGetAllStrings()
        {
            return ds.RoleClaims.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        #endregion

        #region Load Data Methods

        // Add some programmatically-generated objects to the data store
        // Write a method for each entity and remember to check for existing
        // data first.  You will call this/these method(s) from a controller action.
        public bool LoadActors()
        {
            bool load = false;
            var user = HttpContext.Current.User.Identity.Name;
            if (ds.Actors.Count()==0)
            {

                ds.Actors.Add(new Actor() 
                {
                    Name = "Moses Harry Horwitz",
                    AlternativeName = "Moe Howard",
                    Height = 1.61, 
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1b/Moe_Howard_1937_%28cropped%29.jpg",
                    BirthDate = new DateTime(1897,6,19),
                    Executive = user
                
                });

                //ds.Actors.Add(new Actor() { Name = "Louis Feinberg", AlternativeName = "Larry Fine", Height = 163, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/42/Larrydisorder.jpg",BirthDate = new DateTime (1902,10,5) });
                ds.Actors.Add(new Actor() { Name = "Jerome Lester Horwitz",
                    AlternativeName = "Curly Howard",
                    Height = 1.65, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4e/Curlyhoward.jpg",
                    BirthDate = new DateTime(1903, 10, 22),
                    Executive=user
                });
                ds.Actors.Add(new Actor() { 
                    Name = "Henry Cavill",
                    Height = 1.85,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/30/Henry_Cavill_%2848417913146%29_%28cropped%29.jpg",
                    BirthDate = new DateTime(1983, 05, 05),
                    Executive=user
                });
                
                ds.SaveChanges();
                load = true;
            }
            return load ;

        }
        public bool LoadShows()
        {

            var user = HttpContext.Current.User.Identity.Name;
            bool load = false;
            if (ds.Shows.Count()==0)
            {
                var moeHoward = ds.Actors.SingleOrDefault(a => a.AlternativeName == "Moe Howard");
                var henryCavil = ds.Actors.SingleOrDefault(a => a.Name == "Henry Cavill");
                ds.Shows.Add(new Show
                {
                    Actors = new Actor[] { moeHoward },
                    Name = "Masters of Comedy Vol. 5",
                    ImageUrl = "https://contentcafe2.btol.com/ContentCafe/Jacket.aspx?userID=EBSPL97865&password=CC18442&Value=777966861692&content=L&Return=1&Type=L",
                    ReleaseDate = new DateTime(2007, 1, 1), //Actual exact release date unknown.
                    Genre = "Comedy",
                    Coordinator= user
                });
                ds.Shows.Add(new Show
                {
                    Actors = new Actor[] { henryCavil },
                    Name = "The Witcher",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/23/The_Witcher_Title_Card.png",
                    ReleaseDate = new DateTime(2019, 12, 19),
                    Genre = "Adventure",
                    Coordinator = user
                });
                ds.SaveChanges();
                load = true;
            }
            return load;
        }
        public bool LoadEpisodes()
        {
            var user = HttpContext.Current.User.Identity.Name;
            bool load = false;
            if (ds.Episodes.Count()==0)
            {
                var comedy = ds.Genres.SingleOrDefault(g => g.Name == "Comedy");
                var masterOfComedy = ds.Shows.SingleOrDefault(s => s.Name == "Masters of Comedy Vol. 5");
                ds.Episodes.Add(new Episode
                {
                    Name = "Swing Paradise of 1946",
                    AirDate = new DateTime(1946, 3, 16),
                    SeasonNumber = 1,
                    Show = masterOfComedy,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Swing_Parade_of_1946_poster.jpg/800px-Swing_Parade_of_1946_poster.jpg",
                    EpisodeNumber =1,
                    Genre = comedy,
                    Clerk=user
                }) ;
                ds.Episodes.Add(new Episode
                {
                    Name = "Jerks of All Trades",
                    AirDate = new DateTime(1949, 10, 12),//Sort of
                    SeasonNumber = 1,
                    Show = masterOfComedy,
                    EpisodeNumber = 2,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BMjA4NDA2OTc1MF5BMl5BanBnXkFtZTgwNDg3NDUyMTE@._V1_.jpg",
                    Genre = comedy,
                    Clerk = user


                });
                ds.Episodes.Add(new Episode
                {
                    Name = "Classic Shorts",
                    AirDate = new DateTime(2009, 1, 1), //This is a collection so I'm just putting the same date as the collection.
                    SeasonNumber = 1,
                    Show = masterOfComedy,
                    EpisodeNumber = 3,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/7f/Lobby36disordercourt.jpg",
                    Genre = comedy,
                    Clerk = user


                });
                var witcher = ds.Shows.SingleOrDefault(s => s.Name == "The Witcher");
                var adventure = ds.Genres.SingleOrDefault(g => g.Name == "Adventure");
                ds.Episodes.Add(new Episode
                {
                    Name = "The End's Beginning",
                    AirDate = new DateTime(2019, 12, 19),
                    SeasonNumber = 1,
                    Show = witcher,
                    EpisodeNumber = 1,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BM2Q5MGU2ZTktYmE4OS00YTkzLWJjZWUtY2RkZWIyNTZkNmVlXkEyXkFqcGdeQXVyODAxMjg3MTU@._V1_.jpg",
                    Genre = adventure,
                    Clerk = user

                });
                ds.Episodes.Add(new Episode
                {
                    Name = "Four Marks",
                    AirDate = new DateTime(2019, 12, 19),
                    SeasonNumber = 1,
                    Show = witcher,
                    EpisodeNumber = 2,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BNTBjNThmNDUtYmY1My00YmQzLWE1ODEtZTQ0M2I5N2Y0ZmE4XkEyXkFqcGdeQXVyMjg2MTMyNTM@._V1_.jpg",
                    Genre = adventure,
                    Clerk = user


                });
                ds.Episodes.Add(new Episode
                {
                    Name = "Betrayer Moon",
                    AirDate = new DateTime(2019, 12, 19),
                    SeasonNumber = 1,
                    Show = witcher,
                    EpisodeNumber = 3,
                    ImageUrl = "https://m.media-amazon.com/images/M/MV5BYjA0YjYzOTctYjM0OC00M2E1LWI3YjMtZjIxNGU2MjJlZjc3XkEyXkFqcGdeQXVyNzgxMzc3OTc@._V1_.jpg",
                    Genre = adventure,
                    Clerk = user
                });

                ds.SaveChanges();
                load = true;
            }
            return load;
        }
        public bool LoadGenre()
        {
            var user = HttpContext.Current.User.Identity.Name;

            bool load = false;
            if (ds.Genres.Count()==0)
            {
                ds.Genres.Add(new Genre() { Name = "Comedy" });
                ds.Genres.Add(new Genre() { Name = "Action" });
                ds.Genres.Add(new Genre() { Name = "Horror" });
                ds.Genres.Add(new Genre() { Name = "Drama" });
                ds.Genres.Add(new Genre() { Name = "Western" });
                ds.Genres.Add(new Genre() { Name = "Mystery" });
                ds.Genres.Add(new Genre() { Name = "Documentary" });
                ds.Genres.Add(new Genre() { Name = "Adventure" });
                ds.Genres.Add(new Genre() { Name = "Film-Noir" });
                ds.Genres.Add(new Genre() { Name = "Crime" });
                ds.SaveChanges();
                load = true;
            }
            return load;
        }
        public bool LoadRoles()
        {
            // User name
            var user = HttpContext.Current.User.Identity.Name;

            // Monitor the progress
            bool done = false;

            // *** Role claims ***
            if (ds.RoleClaims.Count() == 0)
            {
                ds.RoleClaims.Add(new RoleClaim() { Name = "Administrator" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Executive" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Coordinator" });
                ds.RoleClaims.Add(new RoleClaim() { Name = "Clerk" });

                // Add additional role claims here

                ds.SaveChanges();
                done = true;
            }

            return done;
        }

        public bool RemoveData()
        {
            try
            {
                foreach (var e in ds.Actors)
                {
                    ds.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                }

                // Remove additional entities as needed.

                ds.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveDatabase()
        {
            try
            {
                return ds.Database.Delete();
            }
            catch (Exception)
            {
                return false;
            }
        }



        #endregion

        public IEnumerable<GenreBaseViewModel> GenreGetAll()
        {
            var query = ds.Genres
            .OrderBy(g => g.Name);
            return mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBaseViewModel>>(query);

        }

        public IEnumerable<ShowBaseViewModel> ShowGetAll()
        {
            var query = ds.Shows
            .OrderBy(s => s.Name);

            return mapper.Map<IEnumerable<Show>, IEnumerable<ShowBaseViewModel>>(query);
        }
        public ShowWithDetailViewModel ShowGetById(int id)
        {
            var query = ds.Shows
                .Include("Actors")
                .Include("Episodes")
             .SingleOrDefault(show => show.Id == id);
            return (query == null) ? null : mapper.Map<Show, ShowWithDetailViewModel>(query);
        }
        public ShowBaseViewModel ShowAdd(ShowAddViewModel newShow)
        {
            var user = HttpContext.Current.User.Identity.Name;

            var addedShow = ds.Shows.Add(mapper.Map<ShowAddViewModel, Show>(newShow));
         

            addedShow.Coordinator = user;
            foreach (var id in newShow.ActorId)
            {
                var actor = ds.Actors.Find(id);
                if (actor == null)
                {
                    return null;
                }
                else
                {
                    addedShow.Actors.Add(actor);
                }
            }
            ds.SaveChanges();
            return (addedShow == null) ? null : mapper.Map<Show, ShowBaseViewModel>(addedShow);

        }
        public ActorBaseViewModel ActorMediaItemAdd(ActorMediaItemAddViewModel newItem)
        {
            // Validate the associated item
            var a = ds.Actors.Find(newItem.ActorId);

            if (a == null)
            {
                return null;
            }
            else
            {
                // Attempt to add the new item
                var addedItem = new ActorMediaItem();
                ds.ActorMediaItems.Add(addedItem);

                addedItem.Caption = newItem.Caption;
                addedItem.Actor = a;

                // Handle the uploaded photo...

                // First, extract the bytes from the HttpPostedFile object
                byte[] photoBytes = new byte[newItem.ContentUpload.ContentLength];
                newItem.ContentUpload.InputStream.Read(photoBytes, 0, newItem.ContentUpload.ContentLength);

                // Then, configure the new object's properties
                addedItem.Content = photoBytes;
                addedItem.ContentType = newItem.ContentUpload.ContentType;

                ds.SaveChanges();

                return (addedItem == null) ? null : mapper.Map<Actor, ActorBaseViewModel>(a);
            }
        }


        public EpisodeBaseViewModel EpisodeAdd(EpisodeAddViewModel newEpisode)
        {
            var user = HttpContext.Current.User.Identity.Name;
            var show = ds.Shows.Find(newEpisode.ShowId);
            var genre = ds.Genres.Find(newEpisode.GenreId);
            if (genre == null)
            {
                return null;
            }
            else
            {

                var addedEpisode = ds.Episodes.Add(mapper.Map<EpisodeAddViewModel, Episode>(newEpisode));
                byte[] videoBytes = new byte[newEpisode.VideoUpload.ContentLength];
                newEpisode.VideoUpload.InputStream.Read(videoBytes, 0, newEpisode.VideoUpload.ContentLength);

                // Then, configure the new object's properties
                addedEpisode.Video = videoBytes;
                addedEpisode.VideoContentType = newEpisode.VideoUpload.ContentType;

                addedEpisode.Show = show;
                addedEpisode.Genre = genre;
                addedEpisode.Clerk = user;
                ds.SaveChanges();
                return (addedEpisode == null) ? null : mapper.Map<Episode, EpisodeBaseViewModel>(addedEpisode);

            }


        }
        


        public ActorBaseViewModel ActorAdd(ActorAddViewModel newActor)
        {
            var user = HttpContext.Current.User.Identity.Name;
            var addedActor = ds.Actors.Add(mapper.Map<ActorAddViewModel, Actor>(newActor));
            addedActor.Executive = user;
            ds.SaveChanges();
            return (addedActor == null) ? null : mapper.Map<Actor, ActorBaseViewModel>(addedActor);
        }

        public IEnumerable<EpisodeBaseViewModel> EpisodeGetAll()
        {
            var query = ds.Episodes.Include("Show")
                        .Include("Genre")
                        .OrderBy(e => e.Show.Name)
                        .OrderBy(e => e.SeasonNumber)
                        .OrderBy(e => e.EpisodeNumber);


            return mapper.Map<IEnumerable<Episode>, IEnumerable<EpisodeBaseViewModel>>(query);
        }
        public EpisodeBaseViewModel EpisodeGetById(int id)
        {
            var query = ds.Episodes
                    .Include("Show")
                    .Include("Genre")
                    .SingleOrDefault(episode => episode.Id == id);
                return (query == null) ? null : mapper.Map<Episode, EpisodeBaseViewModel>(query);
        }
        public EpisodeVideoViewModel EpisodeVideoGetById(int id)
        {
            var query = ds.Episodes.Find(id);
            return (query == null) ? null : mapper.Map<Episode, EpisodeVideoViewModel>(query);
        }
        public IEnumerable<ActorBaseViewModel> ActorGetAll()
        {

            var query = ds.Actors
                .OrderBy(a => a.Name);

            return mapper.Map<IEnumerable<Actor>, IEnumerable<ActorBaseViewModel>>(query);

        }
        public ActorBaseViewModel ActorGetById(int id)
        {
            var query = ds.Actors
            .SingleOrDefault(actor => actor.Id == id);
            return (query == null) ? null : mapper.Map<Actor, ActorBaseViewModel>(query);
        }
        public ActorWithShowInfoViewModel ActorGetWithShowInfo(int id)
        {
            var query = ds.Actors.Include("Shows")
                        .Include("ActorMediaItems")
                        .SingleOrDefault(actor=> actor.Id == id);
            query.ActorMediaItems.OrderByDescending(actorItem => actorItem.Caption);
            return (query == null) ? null : mapper.Map<Actor, ActorWithShowInfoViewModel>(query);
        }
        public ActorMediaItemWithContentViewModel ActorMediaItemGetById(int id)
        {
            var query = ds.ActorMediaItems
                        .SingleOrDefault(actorMediaItem => actorMediaItem.Id == id);
            return (query == null) ? null : mapper.Map<ActorMediaItem, ActorMediaItemWithContentViewModel>(query);

        }
    }
    #region RequestUser Class

    // This "RequestUser" class includes many convenient members that make it
    // easier work with the authenticated user and render user account info.
    // Study the properties and methods, and think about how you could use this class.

    // How to use...
    // In the Manager class, declare a new property named User:
    //    public RequestUser User { get; private set; }

    // Then in the constructor of the Manager class, initialize its value:
    //    User = new RequestUser(HttpContext.Current.User as ClaimsPrincipal);

    public class RequestUser
    {
        // Constructor, pass in the security principal
        public RequestUser(ClaimsPrincipal user)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                Principal = user;

                // Extract the role claims
                RoleClaims = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

                // User name
                Name = user.Identity.Name;

                // Extract the given name(s); if null or empty, then set an initial value
                string gn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
                if (string.IsNullOrEmpty(gn)) { gn = "(empty given name)"; }
                GivenName = gn;

                // Extract the surname; if null or empty, then set an initial value
                string sn = user.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname).Value;
                if (string.IsNullOrEmpty(sn)) { sn = "(empty surname)"; }
                Surname = sn;

                IsAuthenticated = true;
                // You can change the string value in your app to match your app domain logic
                IsAdmin = user.HasClaim(ClaimTypes.Role, "Admin") ? true : false;
            }
            else
            {
                RoleClaims = new List<string>();
                Name = "anonymous";
                GivenName = "Unauthenticated";
                Surname = "Anonymous";
                IsAuthenticated = false;
                IsAdmin = false;
            }

            // Compose the nicely-formatted full names
            NamesFirstLast = $"{GivenName} {Surname}";
            NamesLastFirst = $"{Surname}, {GivenName}";
        }

        // Public properties
        public ClaimsPrincipal Principal { get; private set; }

        public IEnumerable<string> RoleClaims { get; private set; }

        public string Name { get; set; }

        public string GivenName { get; private set; }

        public string Surname { get; private set; }

        public string NamesFirstLast { get; private set; }

        public string NamesLastFirst { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool IsAdmin { get; private set; }

        public bool HasRoleClaim(string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(ClaimTypes.Role, value) ? true : false;
        }

        public bool HasClaim(string type, string value)
        {
            if (!IsAuthenticated) { return false; }
            return Principal.HasClaim(type, value) ? true : false;
        }
    }

    #endregion

}