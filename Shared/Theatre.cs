﻿global using MovieTuple = (string title, int runLengthMinutes);
global using ShowtimeTuple = (string title, System.DateTime showtime);

using Data;

namespace Shared;

public static class Theatre
{
  public static List<MovieTuple> Movies = new List<MovieTuple>();
  public static List<ShowtimeTuple> Showtimes = new List<ShowtimeTuple>();

  public static void AddMovie(string title, int runLengthMinutes)
  {
    foreach(var movie in Movies)
    {
      if(movie.title == title)
      {
        throw new InvalidOperationException("Cannot add duplicate movie");
      }
    }
    MovieTuple newMovie = new MovieTuple();
    newMovie.title = title;
    newMovie.runLengthMinutes = runLengthMinutes;
    Movies.Add(newMovie);
  }

  public static void AddShowtime(string title, DateTime dateTime)
  {
  }

  public static void ResetData()
  {
    // this function is only used in tests to make sure we start on a blank state
    Movies = new List<MovieTuple>();
    Showtimes = new List<ShowtimeTuple>();
  }

  public static void LoadMoviesAndShowtimesFromFiles()
  {
    Movies = Persistence.LoadMovies();
    Showtimes = Persistence.LoadShowtimes();
  }

  public static void SaveMoviesAndShowtimesToFiles()
  {
    Persistence.PersistMovies(Movies);
    Persistence.PersistShowtimes(Showtimes);
  }

}
