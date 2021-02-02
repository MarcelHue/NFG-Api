using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NetFlixGo.DTOs;
using NetFlixGo.Entities;
using Type = NetFlixGo.Entities.Type;

namespace NetFlixGo.Repositories
{
    public class MongoDbRepository : IMovieRepository, ITypeRepository, IUserRepository, IGenreRepository
    {
        private const string DatabaseName = "NFG";
        private readonly IMongoCollection<Genre> _genreCollection;
        private readonly IMongoCollection<Movie> _movieCollection;
        private readonly IMongoCollection<Type> _typeCollection;
        private readonly IMongoCollection<User> _userCollection;
        private readonly FilterDefinitionBuilder<Genre> _genreFilter = Builders<Genre>.Filter;
        private readonly FilterDefinitionBuilder<Movie> _movieFilter = Builders<Movie>.Filter;
        private readonly FilterDefinitionBuilder<Type> _typeFilter = Builders<Type>.Filter;
        private readonly FilterDefinitionBuilder<User> _userFilter = Builders<User>.Filter;

        public MongoDbRepository(IMongoClient mongoClient)
        {
            _movieCollection = mongoClient.GetDatabase(DatabaseName).GetCollection<Movie>("Movies");
            _typeCollection = mongoClient.GetDatabase(DatabaseName).GetCollection<Type>("Type");
            _userCollection = mongoClient.GetDatabase(DatabaseName).GetCollection<User>("User");
            _genreCollection = mongoClient.GetDatabase(DatabaseName).GetCollection<Genre>("Genre");
        }


        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _genreCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Genre> GetGenreAsync(Guid genreId)
        {
            var filter = _genreFilter.Eq(genre => genre.Id, genreId);
            return await _genreCollection.Find(filter).SingleAsync();
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            await _genreCollection.InsertOneAsync(genre);
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            var filter = _genreFilter.Eq(genre => genre.Id, genre.Id);

            await _genreCollection.ReplaceOneAsync(filter, genre);
        }

        public async Task DeleteGenreAsync(Guid genreId)
        {
            var filter = _genreFilter.Eq(genre => genre.Id, genreId);
            await _genreCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Movie> GetMovieAsync(Guid movieId)
        {
            var filter = _movieFilter.Eq(movie => movie.Id, movieId);
            return await _movieCollection.Find(filter).SingleAsync();
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            await _movieCollection.InsertOneAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            var filter = _movieFilter.Eq(movie => movie.Id, movie.Id);
            await _movieCollection.ReplaceOneAsync(filter, movie);
        }

        public async Task DeleteMovieAsync(Guid movieId)
        {
            var filter = _movieFilter.Eq(movie => movie.Id, movieId);
            await _movieCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Type>> GetTypesAsync()
        {
            return await _typeCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Type> GetTypeAsync(Guid typeId)
        {
            var filter = _typeFilter.Eq(type => type.Id, typeId);
            return await _typeCollection.Find(filter).SingleAsync();
        }

        public async Task CreateTypeAsync(Type type)
        {
            await _typeCollection.InsertOneAsync(type);
        }

        public async Task UpdateTypeAsync(Type type)
        {
            var filter = _typeFilter.Eq(type => type.Id, type.Id);
            await _typeCollection.ReplaceOneAsync(filter, type);
        }

        public async Task DeleteTypeAsync(Guid typeId)
        {
            var filter = _typeFilter.Eq(type => type.Id, typeId);
            await _typeCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            var filter = _userFilter.Eq(user => user.Id, userId);
            return await _userCollection.Find(filter).SingleAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = _userFilter.Eq(user => user.Id, user.Id);
            await _userCollection.ReplaceOneAsync(filter, user);
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var filter = _userFilter.Eq(user => user.Id, userId);
            await _userCollection.DeleteOneAsync(filter);
        }

        public async Task<User> AuthUserAsync(toAuthUserDto toToAuth)
        {
            var filter1 = _userFilter.Eq(user => user.EMail, toToAuth.EMail);
            var filter2 = _userFilter.Eq(user => user.Password, toToAuth.Password);

            return await _userCollection.Find(filter1 & filter2).SingleAsync();
        }
    }
}